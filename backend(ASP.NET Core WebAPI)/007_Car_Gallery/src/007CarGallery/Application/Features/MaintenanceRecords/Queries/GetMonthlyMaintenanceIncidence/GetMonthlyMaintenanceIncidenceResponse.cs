using NArchitecture.Core.Application.Dtos;
using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintenanceRecords.Queries.GetMonthlyMaintenanceIncidence;
public class GetMonthlyMaintenanceIncidenceResponse : IDto
{
    public string Month { get; set; }
    public int MonthCount { get; set; }
}
