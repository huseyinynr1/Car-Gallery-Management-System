using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetCarsCountByBrandName;
public class GetCarsCountByBrandNameResponse : IResponse
{
    public string BrandName { get; set; }
    public int Count { get; set; }
}
