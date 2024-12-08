using Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.NumberOfCarsInMaintenance;
public class NumberOfCarInMaintenanceQuery : IRequest<NumberOfCarInMaintenanceResponse>
{
    public string BrandName { get; set; }
    public string ModelName { get; set; }
    public int Year { get; set; }
    public string TransmissionType { get; set; }
    public string FuelType { get; set; }
    public string Status { get; set; }


}

public class NumberOfCarInMaintenanceQueryHandler : IRequestHandler<NumberOfCarInMaintenanceQuery, NumberOfCarInMaintenanceResponse>
{
    private readonly ICarRepository _carRepository;

    public NumberOfCarInMaintenanceQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<NumberOfCarInMaintenanceResponse> Handle(NumberOfCarInMaintenanceQuery request, CancellationToken cancellationToken)
    {
        int numberOfMaintenanceCount = await _carRepository.GetTotalCarCountAsync(c => c.Brand.Name == request.BrandName
        && c.Model.Name == request.ModelName
        && c.Transmission.Type == request.TransmissionType
        && c.Fuel.Type == request.FuelType
        && c.CarStatus.Status == request.Status
        && c.Year == request.Year,
        cancellationToken);

        NumberOfCarInMaintenanceResponse response = new NumberOfCarInMaintenanceResponse() { Number = numberOfMaintenanceCount };
        return response;

    }
}