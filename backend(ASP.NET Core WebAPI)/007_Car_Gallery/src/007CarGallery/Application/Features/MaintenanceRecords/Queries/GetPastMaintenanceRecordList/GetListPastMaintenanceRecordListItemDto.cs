using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintenanceRecords.Queries.GetPastMaintenanceRecordList;
public class GetListPastMaintenanceRecordListItemDto : IDto
{
    public string BrandName { get; set; }
    public string ModelName { get; set; }
    public string Type { get; set; }
    public string MaintenanceState { get; set; }
    public string MaintenanceType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DealPrice { get; set; }
}
