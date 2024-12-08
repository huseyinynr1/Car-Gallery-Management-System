using Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetCarStatusInStorage;
public class GetCarStatusInStorageQuery : IRequest<GetCarStatusInStorageResponse>
{
    public string Status { get; set; }
}

public class GetCarStatusInStorageQueryHandler : IRequestHandler<GetCarStatusInStorageQuery, GetCarStatusInStorageResponse>
{
    private readonly ICarRepository _carRepository;

    public GetCarStatusInStorageQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<GetCarStatusInStorageResponse> Handle(GetCarStatusInStorageQuery request, CancellationToken cancellationToken)
    {
        int numberOfCarsAvaliableForSale = await _carRepository.GetTotalCarCountAsync(c => c.CarStatus.Status == request.Status);
        GetCarStatusInStorageResponse response = new GetCarStatusInStorageResponse { Count = numberOfCarsAvaliableForSale };
        return response;

    }
}