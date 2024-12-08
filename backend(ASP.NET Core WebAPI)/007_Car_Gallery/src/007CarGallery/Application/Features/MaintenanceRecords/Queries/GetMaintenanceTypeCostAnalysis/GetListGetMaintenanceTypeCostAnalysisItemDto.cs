using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintenanceRecords.Queries.GetMaintenanceTypeCostAnalysis;
public class GetListGetMaintenanceTypeCostAnalysisItemDto : IDto
{
    public string Type { get; set; }
    public int Count { get; set; }
    public int Cost { get; set; }
}
