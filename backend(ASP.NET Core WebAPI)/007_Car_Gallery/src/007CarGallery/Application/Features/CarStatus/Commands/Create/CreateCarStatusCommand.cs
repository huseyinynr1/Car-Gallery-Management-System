using Application.Features.CarStatus.Constants;
using Application.Features.CarStatus.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CarStatus.Constants.CarStatusOperationClaims;

namespace Application.Features.CarStatus.Commands.Create;

public class CreateCarStatusCommand : IRequest<CreatedCarStatusResponse>, ISecuredRequest
{
    public string Status { get; set; }

    public string[] Roles => [Admin, Write, CarStatusOperationClaims.Create];

    public class CreateCarStatusCommandHandler : IRequestHandler<CreateCarStatusCommand, CreatedCarStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarStatusRepository _carStatusRepository;
        private readonly CarStatusBusinessRules _carStatusBusinessRules;

        public CreateCarStatusCommandHandler(IMapper mapper, ICarStatusRepository carStatusRepository,
                                         CarStatusBusinessRules carStatusBusinessRules)
        {
            _mapper = mapper;
            _carStatusRepository = carStatusRepository;
            _carStatusBusinessRules = carStatusBusinessRules;
        }

        public async Task<CreatedCarStatusResponse> Handle(CreateCarStatusCommand request, CancellationToken cancellationToken)
        {
            CarStatusEntity carStatus = _mapper.Map<CarStatusEntity>(request);

            await _carStatusRepository.AddAsync(carStatus);

            CreatedCarStatusResponse response = _mapper.Map<CreatedCarStatusResponse>(carStatus);
            return response;
        }
    }
}