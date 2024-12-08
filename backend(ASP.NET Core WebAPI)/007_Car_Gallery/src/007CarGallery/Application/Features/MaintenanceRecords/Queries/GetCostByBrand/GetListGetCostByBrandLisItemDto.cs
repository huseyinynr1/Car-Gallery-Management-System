using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintenanceRecords.Queries.GetCostByBrand;
public class GetListGetCostByBrandLisItemDto :IDto
{
    public string BrandName { get; set; }
    public int YearCost { get; set; }
    public int MonthCost { get; set; }
}
