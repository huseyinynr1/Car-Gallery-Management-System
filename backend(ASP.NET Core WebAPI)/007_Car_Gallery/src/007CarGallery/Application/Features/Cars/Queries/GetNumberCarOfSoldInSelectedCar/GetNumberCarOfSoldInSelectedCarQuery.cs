using Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetNumberCarOfSoldInSelectedCar;
public class GetNumberCarOfSoldInSelectedCarQuery : IRequest<GetNumberCarOfSoldInSelectedCarResponse>
{
    public string BrandName { get; set; }
    public string ModelName { get; set; }
    public string TransmissionType { get; set; }
    public string FuelType { get; set; }
    public string Status { get; set; }
    public int Year { get; set; }
}


public class GetNumberCarOfSoldInSelectedCarQueryHandler : IRequestHandler<GetNumberCarOfSoldInSelectedCarQuery, GetNumberCarOfSoldInSelectedCarResponse>
{
    private readonly ICarRepository _carRepository;

    public GetNumberCarOfSoldInSelectedCarQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<GetNumberCarOfSoldInSelectedCarResponse> Handle(GetNumberCarOfSoldInSelectedCarQuery request, CancellationToken cancellationToken)
    {
        int numberOfSoldCar = await _carRepository.GetTotalCarCountAsync(c => c.Brand.Name == request.BrandName
        && c.Model.Name == request.ModelName
        && c.Transmission.Type == request.TransmissionType
        && c.Fuel.Type == request.FuelType
        && c.CarStatus.Status == request.Status
        && c.Year == request.Year,
        cancellationToken);

        GetNumberCarOfSoldInSelectedCarResponse response = new GetNumberCarOfSoldInSelectedCarResponse() { Number = numberOfSoldCar };
        return response;
    }
}