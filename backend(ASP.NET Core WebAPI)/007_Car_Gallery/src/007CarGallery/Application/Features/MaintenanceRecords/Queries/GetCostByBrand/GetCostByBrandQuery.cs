using Application.Services.Repositories;
using Application.Services.Utilities.DateTime;
using MediatR;
using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintenanceRecords.Queries.GetCostByBrand;
public class GetCostByBrandQuery : IRequest<GetListResponse<GetListGetCostByBrandLisItemDto>>
{
    public int Year { get; set; }
    public int Month { get; set; }
}

public class GetCostByBrandQueryHandler : IRequestHandler<GetCostByBrandQuery, GetListResponse<GetListGetCostByBrandLisItemDto>>
{
    private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;
    private readonly IBrandRepository _brandRepository;

    public GetCostByBrandQueryHandler(IMaintenanceRecordRepository maintenanceRecordRepository, IBrandRepository brandRepository)
    {
        _maintenanceRecordRepository = maintenanceRecordRepository;
        _brandRepository = brandRepository;
    }

    public async Task<GetListResponse<GetListGetCostByBrandLisItemDto>> Handle(GetCostByBrandQuery request, CancellationToken cancellationToken)
    {
        var response = new GetListResponse<GetListGetCostByBrandLisItemDto>
        {
            Items = new List<GetListGetCostByBrandLisItemDto>()
        };
        var brands = await _brandRepository.GetListAsync();
        if(brands == null || !brands.Items.Any()) 
        {
            return response;
        }
        
        int year = request.Year;
        int month = request.Month;
        
        foreach (var brand in brands.Items)
        {
             int yearlyCost = await _maintenanceRecordRepository.GetTotalCostAsync(mr => mr.BrandID == brand.Id && mr.StartDate.HasValue && mr.StartDate.Value.Year == year);
             int monthlyCost = await _maintenanceRecordRepository.GetTotalCostAsync(mr => mr.BrandID == brand.Id && mr.StartDate.HasValue && mr.StartDate.Value.Month == month);

             response.Items.Add(new GetListGetCostByBrandLisItemDto { BrandName = brand.Name, MonthCost = monthlyCost, YearCost = yearlyCost });
        }

        return response;



    }
}
