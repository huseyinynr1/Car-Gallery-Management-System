using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintenanceRecords.Queries.GetCostByCarType;
public class GetListGetCostByCarTypeItemDto : IDto
{
    public string Type { get; set; }
    public int Cost { get; set; }
}
