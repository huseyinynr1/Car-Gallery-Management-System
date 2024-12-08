using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetCarByChassisNo;
public class GetCarByChassisNoResponse : IResponse
{
    public int? Id { get; set; }
    public string BrandName { get; set; }
    public string ModelName { get; set; }
    public string ChassisNo { get; set; }
    public string Plate { get; set; }
}
