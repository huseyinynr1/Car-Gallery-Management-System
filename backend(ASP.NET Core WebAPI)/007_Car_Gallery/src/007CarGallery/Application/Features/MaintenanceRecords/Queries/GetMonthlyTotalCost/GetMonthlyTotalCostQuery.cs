using Application.Features.MaintenanceRecords.Rules;
using Application.Services.Repositories;
using Application.Services.Utilities.DateTime;
using MediatR;
using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintenanceRecords.Queries.GetMonthlyTotalCost;
public class GetMonthlyTotalCostQuery : IRequest<GetListResponse<GetListGetMonthlyTotalCostListItemDto>>
{
    public int Year { get; set; } = DateTime.Now.Year;

}

public class GetMonthlyTotalCostQueryHandler : IRequestHandler<GetMonthlyTotalCostQuery, GetListResponse<GetListGetMonthlyTotalCostListItemDto>>
{
    private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;
    private readonly IMonthNameService _monthNameService;
    private readonly MaintenanceRecordBusinessRules _maintenanceRecordBusinessRules;

    public GetMonthlyTotalCostQueryHandler(IMaintenanceRecordRepository maintenanceRecordRepository, 
        IMonthNameService monthNameService, MaintenanceRecordBusinessRules maintenanceRecordBusinessRules)
    {
        _maintenanceRecordRepository = maintenanceRecordRepository;
        _monthNameService = monthNameService;
        _maintenanceRecordBusinessRules = maintenanceRecordBusinessRules;
    }

    public async Task<GetListResponse<GetListGetMonthlyTotalCostListItemDto>> Handle(GetMonthlyTotalCostQuery request, CancellationToken cancellationToken)
    {
        var responses = new GetListResponse<GetListGetMonthlyTotalCostListItemDto> 
        {
            Items = new List<GetListGetMonthlyTotalCostListItemDto>()
        };

        for(int month = 1; month <= 12; month++) 
        {
            // İlk olarak gerekli şartları sağlayan bakım kayıtları için toplam maliyet değerini alındı
            int totalCost = await _maintenanceRecordRepository.GetTotalCostAsync(predicate: mr => (mr.StartDate.HasValue) &&
            (mr.StartDate.Value.Year == request.Year) &&
            (mr.StartDate.Value.Month == month) &&
            (mr.MaintenanceState.State != "Planlandı" && mr.MaintenanceState.State != "Beklemede")
             );

            // Toplam bakım sayısı gerekli şartlara göre alındı
            int maintenanceCount = await _maintenanceRecordRepository.GetCountAsync(predicate: mr => mr.StartDate.HasValue &&
            mr.StartDate.Value.Year == request.Year &&
            mr.StartDate.Value.Month == month &&
            mr.MaintenanceState.State != "Planlandı" && mr.MaintenanceState.State != "Beklemede");

            //await _maintenanceRecordBusinessRules.MaintenanceRecordCountShouldExistWhenSelected(maintenanceCount);

            // Mevcut aydaki ortalama maliyet için toplam maliyet bakım sayısına bölündü. 
            double averageCost = maintenanceCount > 0 ?  totalCost / maintenanceCount : averageCost = 0;

            string monthName = _monthNameService.GetMonthName(month); // Aylar int değerlerine göre isimleri atanıp stringe dönüştürüldü.

            responses.Items.Add(new GetListGetMonthlyTotalCostListItemDto { Month = monthName, TotalCost = totalCost, AverageCost = averageCost }); // Oluşan sonuçlar yeni bir liste elemanı olarak eklendi.
        }
        return responses;
    }
}
