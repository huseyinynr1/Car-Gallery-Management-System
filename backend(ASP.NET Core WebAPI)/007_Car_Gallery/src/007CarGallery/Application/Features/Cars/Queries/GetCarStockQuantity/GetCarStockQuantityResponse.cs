using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetCarStockQuantity;
public class GetCarStockQuantityResponse : IResponse
{
    public int StockQuantity { get; set; }
}
