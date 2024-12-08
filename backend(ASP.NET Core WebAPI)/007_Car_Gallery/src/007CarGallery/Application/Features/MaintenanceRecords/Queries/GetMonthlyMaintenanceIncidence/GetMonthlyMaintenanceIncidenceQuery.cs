using Application.Services.MaintenanceRecords;
using Application.Services.Repositories;
using Application.Services.Utilities.DateTime;
using MediatR;
using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintenanceRecords.Queries.GetMonthlyMaintenanceIncidence;
public class GetMonthlyMaintenanceIncidenceQuery : IRequest<GetListResponse<GetMonthlyMaintenanceIncidenceResponse>>
{
    public int Year { get; set; } = DateTime.Now.Year;
}

public class GetMonthlyMaintenanceIncidenceQueryHandler : IRequestHandler<GetMonthlyMaintenanceIncidenceQuery, GetListResponse<GetMonthlyMaintenanceIncidenceResponse>>
{
    private readonly IMaintenanceRecordService _maintenanceRecordService;
    private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;
    private readonly IMonthNameService _monthNameService;

    public GetMonthlyMaintenanceIncidenceQueryHandler(IMaintenanceRecordService maintenanceRecordService, 
        IMaintenanceRecordRepository maintenanceRecordRepository, IMonthNameService monthNameService)
    {
        _maintenanceRecordService = maintenanceRecordService;
        _maintenanceRecordRepository = maintenanceRecordRepository;
        _monthNameService = monthNameService;
    }

    public async Task<GetListResponse<GetMonthlyMaintenanceIncidenceResponse>> Handle(GetMonthlyMaintenanceIncidenceQuery request, CancellationToken cancellationToken)
    {
        int year = request.Year;

        // GetListResponse generic bir sınıf ve içerisinde Items adında bir liste değişkeni tanımlanmıştır. 
        // Burada oluşturulacak her listeyi yeni bir Items olarak tanımlayarak Items listesine eklemek için aşağıdaki yapı kullanılıyor.
        var responses = new GetListResponse<GetMonthlyMaintenanceIncidenceResponse> 
        {
            Items = new List<GetMonthlyMaintenanceIncidenceResponse>()
        
        };

        for (int month = 1; month <= 12; month++)  // Bir yıl 12 aydır, 1'den 12. aya kadar verileri, ay ay olarak almak için for döngüsü kullanıldı.
        {
            int count = await _maintenanceRecordRepository.GetCountAsync(mr => (mr.MaintenanceState.State != "Planlandı")
            && mr.StartDate.HasValue
            && mr.StartDate.Value.Year == year
            && mr.StartDate.Value.Month == month,
            cancellationToken: cancellationToken); // Her bir ay için baıkm sayısı alma metodu
            string monthName = _monthNameService.GetMonthName(month); // Ay olarak belirlenen 1 sayısını string olarak ay adı "Ocak" olarak çevirme metodu

            responses.Items.Add(
                new GetMonthlyMaintenanceIncidenceResponse { Month = monthName, MonthCount = count });
        } // Hey ayda oluşturulan verileri response'a ekleme.
        return responses;
    }
}
