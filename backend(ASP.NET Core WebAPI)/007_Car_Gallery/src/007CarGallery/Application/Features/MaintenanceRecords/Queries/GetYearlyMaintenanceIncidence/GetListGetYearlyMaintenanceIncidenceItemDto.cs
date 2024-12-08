using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintenanceRecords.Queries.GetYearlyMaintenanceIncidence;
public class GetListGetYearlyMaintenanceIncidenceItemDto : IDto
{
    public int Year { get; set; }
    public int YearCount { get; set; }
}
