using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintenanceRecords.Queries.GetYearlyTotalCost;
public class GetListGetYearlyTotalCostListItemDto :IDto
{
    public int Year { get; set; }
    public int TotalCost { get; set; }
    public double AverageCost { get; set; }
}
