using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintenanceRecords.Queries.GetRecordByFilter;
public class GetRecordByFilterQuery : IRequest<GetListResponse<GetRecordByFilterItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public string? BrandName { get; set; }
    public string? ModelName { get; set; }
    public string? Type { get; set; }
    public string? State { get; set; }
    public DateTime? Time { get; set; }
    public int? MinDealPrice { get; set; }
    public int? MaxDealPrice { get; set; }
}

public class GetRecordByFilterQueryHandler : IRequestHandler<GetRecordByFilterQuery, GetListResponse<GetRecordByFilterItemDto>>
{
    private readonly IMapper _mapper;
    private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;

    public GetRecordByFilterQueryHandler(IMapper mapper, IMaintenanceRecordRepository maintenanceRecordRepository)
    {
        _mapper = mapper;
        _maintenanceRecordRepository = maintenanceRecordRepository;
    }

    public async Task<GetListResponse<GetRecordByFilterItemDto>> Handle(GetRecordByFilterQuery request, CancellationToken cancellationToken)
    {
        IPaginate<MaintenanceRecord> maintenanceRecord = await _maintenanceRecordRepository.GetListAsync(
            predicate: mr =>(request.BrandName == "" || mr.Brand.Name == request.BrandName) &&
            (request.ModelName == "" || mr.Model.Name == request.ModelName ) && (request.Type == "" || mr.MaintenanceType.Type == request.Type)
            && (request.State == "" || mr.MaintenanceState.State == request.State)
            && (!request.Time.HasValue || mr.StartDate >= request.Time.Value)
            && (!request.MinDealPrice.HasValue || mr.DealPrice >= request.MinDealPrice.Value)
            && (!request.MaxDealPrice.HasValue || mr.DealPrice <= request.MaxDealPrice.Value),
            include: mr => mr.Include(mr => mr.Brand).Include(mr => mr.Model).Include(mr => mr.MaintenanceType).Include(mr => mr.MaintenanceState),
            cancellationToken: cancellationToken);

        GetListResponse<GetRecordByFilterItemDto> response = _mapper.Map<GetListResponse<GetRecordByFilterItemDto>>(maintenanceRecord);
        return response;
    }
}
