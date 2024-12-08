using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetNumberCarOfSoldInSelectedCar;
public class GetNumberCarOfSoldInSelectedCarResponse : IResponse
{
    public int Number { get; set; }
}
