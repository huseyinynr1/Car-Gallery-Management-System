using Application.Features.MaintenanceRecords.Queries.GetMonthlyTotalCost;
using Application.Features.MaintenanceRecords.Rules;
using Application.Services.Repositories;
using Application.Services.Utilities.DateTime;
using MediatR;
using NArchitecture.Core.Application.Responses;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintenanceRecords.Queries.GetYearlyTotalCost;
public class GetYearlyTotalCostQuery : IRequest<GetListResponse<GetListGetYearlyTotalCostListItemDto>>
{
    public int StartYear { get; set; } = DateTime.Now.Year;
    public int NumberOfYear { get; set; }
}

public class GetYearlyTotalCostQueryHandler : IRequestHandler<GetYearlyTotalCostQuery, GetListResponse<GetListGetYearlyTotalCostListItemDto>>
{
    private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;

    public GetYearlyTotalCostQueryHandler(IMaintenanceRecordRepository maintenanceRecordRepository)
    {
        _maintenanceRecordRepository = maintenanceRecordRepository;
    }

    public async Task<GetListResponse<GetListGetYearlyTotalCostListItemDto>> Handle(GetYearlyTotalCostQuery request, CancellationToken cancellationToken)
    {
        var responses = new GetListResponse<GetListGetYearlyTotalCostListItemDto>
        {
            Items = new List<GetListGetYearlyTotalCostListItemDto>()
        };

        int endYear = request.StartYear - request.NumberOfYear; // Kullanıcı kaç yıllık verileri istiyorsa , şimdiki zamandaki yıldan çıkararak o endYear değişkeninde tutuyoruz.

        for (int year = request.StartYear; year >= endYear; year--)
        {
            // İlk olarak gerekli şartları sağlayan bakım kayıtları için toplam maliyet değerini alındı
            int totalCost = await _maintenanceRecordRepository.GetTotalCostAsync(predicate: mr => mr.StartDate.HasValue &&
            mr.StartDate.Value.Year == year &&
            mr.MaintenanceState.State != "Planlandı" && mr.MaintenanceState.State != "Beklemede"
             );

            // Toplam bakım sayısı gerekli şartlara göre alındı
            int maintenanceCount = await _maintenanceRecordRepository.GetCountAsync(predicate: mr => mr.StartDate.HasValue &&
            mr.StartDate.Value.Year == year &&
            mr.MaintenanceState.State != "Planlandı" && mr.MaintenanceState.State != "Beklemede");


            // Mevcut aydaki ortalama maliyet için toplam maliyet bakım sayısına bölündü. 
            double averageCost = maintenanceCount > 0 ? totalCost / maintenanceCount : averageCost = 0;

            responses.Items.Add(new GetListGetYearlyTotalCostListItemDto { Year = year , TotalCost = totalCost, AverageCost = averageCost }); // Oluşan sonuçlar yeni bir liste elemanı olarak eklendi.
        }
        return responses;
    }
}
