using Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetCarsCountByBrandName;
public class GetCarsCountByBrandNameQuery : IRequest<GetCarsCountByBrandNameResponse>
{
    public string BrandName { get; set; }
}

public class GetCarsCountByBrandNameQueryHandler : IRequestHandler<GetCarsCountByBrandNameQuery, GetCarsCountByBrandNameResponse>
{
    private readonly ICarRepository _carRepository;

    public GetCarsCountByBrandNameQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;

    }

    public async Task<GetCarsCountByBrandNameResponse> Handle(GetCarsCountByBrandNameQuery request, CancellationToken cancellationToken)
    {
        int carCountByBrandName = await _carRepository.GetCarsCountByBrandNameAsync(request.BrandName);

        GetCarsCountByBrandNameResponse response = new GetCarsCountByBrandNameResponse { BrandName = request.BrandName, Count = carCountByBrandName };
        return response;

    }
}