using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.NumberOfCarsInMaintenance;
public class NumberOfCarInMaintenanceResponse : IResponse
{
    public int Number { get; set; }
}
