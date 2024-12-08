using Application.Services.MaintenancePlanningRecords;
using Application.Services.MaintenanceRecords;
using Application.Services.Repositories;
using MediatR;
using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintenanceRecords.Queries.GetYearlyMaintenanceIncidence;
public class GetYearlyMaintenanceIncidenceQuery : IRequest<GetListResponse<GetListGetYearlyMaintenanceIncidenceItemDto>>
{
    public int StartYear { get; set; } = DateTime.Now.Year;
    public int NumberOfYear { get; set; } 
}

public class GetYearlyMaintenanceIncidenceQueryHandler : IRequestHandler<GetYearlyMaintenanceIncidenceQuery, GetListResponse<GetListGetYearlyMaintenanceIncidenceItemDto>>
{
    private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;

    public GetYearlyMaintenanceIncidenceQueryHandler(IMaintenanceRecordRepository maintenanceRecordRepository)
    {
        _maintenanceRecordRepository = maintenanceRecordRepository;
    }

    public async Task<GetListResponse<GetListGetYearlyMaintenanceIncidenceItemDto>> Handle(GetYearlyMaintenanceIncidenceQuery request, CancellationToken cancellationToken)
    {
        // Yıllar için bakım sayılarını alıp bir liste olarak oluşturmak için , her items için bir liste oluşturuyoruz. 
        var responses = new GetListResponse<GetListGetYearlyMaintenanceIncidenceItemDto>
        {
            Items = new List<GetListGetYearlyMaintenanceIncidenceItemDto>()
        };
        int endYear = request.StartYear - request.NumberOfYear; // Kullanıcı kaç yıllık verileri istiyorsa , şimdiki zamandaki yıldan çıkararak o endYear değişkeninde tutuyoruz.
        for(int year = request.StartYear; year >= endYear; year--) 
        {
            int count = await _maintenanceRecordRepository.GetCountAsync(mr => (mr.MaintenanceState.State != "Tamamlandı")
            && mr.StartDate.HasValue
            && mr.StartDate.Value.Year == year,
            cancellationToken: cancellationToken); // Yıllara göre bakım sayısını verecek metodu çağırıyoruz.
            responses.Items.Add(
                new GetListGetYearlyMaintenanceIncidenceItemDto { Year = year, YearCount = count }); // Gelen verileri manuel olarak mapliyoruz.
        }
        return responses;
    }
}
