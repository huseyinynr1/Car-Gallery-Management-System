using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Responses;
using static Application.Features.Models.Constants.ModelsOperationClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Application.Features.Brands.Rules;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Model = Domain.Entities.Model;
using NArchitecture.Core.Application.Requests;
using Microsoft.EntityFrameworkCore;
namespace Application.Features.Models.Queries.GetModelByBrand;
public class GetModelByBrandQuery: IRequest<GetListResponse<GetListGetModelByBrandListItemDto>> 
{
    public PageRequest PageRequest { get; set; }
    public string BrandName { get; set; }

    //public string[] Roles => [Admin, Read];
}
public class GetModelByBrandQueryHandler : IRequestHandler<GetModelByBrandQuery, GetListResponse<GetListGetModelByBrandListItemDto>>
{ 
    private readonly IMapper _mapper;
    private readonly IModelRepository _modelRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly BrandBusinessRules _brandBusinessRules;

    public GetModelByBrandQueryHandler(IMapper mapper, IModelRepository modelRepository, IBrandRepository brandRepository, BrandBusinessRules brandBusinessRules)
    {
        _mapper = mapper;
        _modelRepository = modelRepository;
        _brandRepository = brandRepository;
        _brandBusinessRules = brandBusinessRules;
    }

    public async Task<GetListResponse<GetListGetModelByBrandListItemDto>> Handle(GetModelByBrandQuery request, CancellationToken cancellationToken)
    {
        var brand = await _brandRepository.GetAsync(b => b.Name == request.BrandName);

        
        Console.WriteLine($"Brand: {brand?.Id}, Name: {brand?.Name}");
        
        await _brandBusinessRules.BrandShouldExistWhenSelected(brand);

        int pageIndex = request.PageRequest?.PageIndex ?? 0; // Null ise 0 kullan
        int pageSize = request.PageRequest?.PageSize ?? 50; // Null ise 50 kullan


        IPaginate<Model> models = await _modelRepository.GetListAsync(
            index: pageIndex,
            size: pageSize,
            predicate: m => m.BrandId == brand.Id,
            cancellationToken:cancellationToken);
        GetListResponse<GetListGetModelByBrandListItemDto> response = _mapper.Map<GetListResponse<GetListGetModelByBrandListItemDto>>(models);
        
        return response;
    }
}



