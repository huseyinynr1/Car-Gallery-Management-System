using Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetCarStockQuantity;
public class GetCarStockQuantityQuery : IRequest<GetCarStockQuantityResponse>
{
    public string BrandName { get; set; }
    public string ModelName { get; set; }
    public int Year { get; set; }
    public string TransmissionType { get; set; }
    public string FuelType { get; set; }
}

public class GetCarStockQuantityQueryHandler : IRequestHandler<GetCarStockQuantityQuery, GetCarStockQuantityResponse>
{
    private readonly ICarRepository _carRepository;

    public GetCarStockQuantityQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<GetCarStockQuantityResponse> Handle(GetCarStockQuantityQuery request, CancellationToken cancellationToken)
    {
        int carStockQuantity = await _carRepository.GetTotalCarCountAsync(c => c.Brand.Name == request.BrandName
        && c.Model.Name == request.ModelName
        && c.Year == request.Year
        && c.Transmission.Type == request.TransmissionType
        && c.Fuel.Type == request.FuelType,
        cancellationToken);

        GetCarStockQuantityResponse response = new GetCarStockQuantityResponse { StockQuantity = carStockQuantity };
        return response;
    }
}