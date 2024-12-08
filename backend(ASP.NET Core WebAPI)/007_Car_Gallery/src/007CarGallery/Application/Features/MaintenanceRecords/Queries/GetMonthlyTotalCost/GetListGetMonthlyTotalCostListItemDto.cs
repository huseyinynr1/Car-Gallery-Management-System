using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintenanceRecords.Queries.GetMonthlyTotalCost;
public class GetListGetMonthlyTotalCostListItemDto : IDto
{
    public string Month { get; set; }
    public int TotalCost { get; set; }
    public double AverageCost { get; set; }
}
