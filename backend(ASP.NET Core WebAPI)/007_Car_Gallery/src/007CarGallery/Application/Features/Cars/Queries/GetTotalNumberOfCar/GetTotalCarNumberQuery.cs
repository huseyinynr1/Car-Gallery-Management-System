using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetTotalNumberOfCar;
public class GetTotalCarNumberQuery : IRequest<GetTotalCarNumberResponse>
{

}

public class GetTotalCarNumberQueryHandler : IRequestHandler<GetTotalCarNumberQuery, GetTotalCarNumberResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetTotalCarNumberQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<GetTotalCarNumberResponse> Handle(GetTotalCarNumberQuery request, CancellationToken cancellationToken)
    {
        int totalCarCount = await _carRepository.GetTotalCarCountAsync();

        return new GetTotalCarNumberResponse { TotalCarNumber = totalCarCount };
    }
}