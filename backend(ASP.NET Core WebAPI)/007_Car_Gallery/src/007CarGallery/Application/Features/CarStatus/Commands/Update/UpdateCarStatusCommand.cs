using Application.Features.CarStatus.Constants;
using Application.Features.CarStatus.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CarStatus.Constants.CarStatusOperationClaims;

namespace Application.Features.CarStatus.Commands.Update;

public class UpdateCarStatusCommand : IRequest<UpdatedCarStatusResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public string Status { get; set; }

    public string[] Roles => [Admin, Write, CarStatusOperationClaims.Update];

    public class UpdateCarStatusCommandHandler : IRequestHandler<UpdateCarStatusCommand, UpdatedCarStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarStatusRepository _carStatusRepository;
        private readonly CarStatusBusinessRules _carStatusBusinessRules;

        public UpdateCarStatusCommandHandler(IMapper mapper, ICarStatusRepository carStatusRepository,
                                         CarStatusBusinessRules carStatusBusinessRules)
        {
            _mapper = mapper;
            _carStatusRepository = carStatusRepository;
            _carStatusBusinessRules = carStatusBusinessRules;
        }

        public async Task<UpdatedCarStatusResponse> Handle(UpdateCarStatusCommand request, CancellationToken cancellationToken)
        {
            CarStatusEntity? carStatus = await _carStatusRepository.GetAsync(predicate: cs => cs.Id == request.Id, cancellationToken: cancellationToken);
            await _carStatusBusinessRules.CarStatusShouldExistWhenSelected(carStatus);
            carStatus = _mapper.Map(request, carStatus);

            await _carStatusRepository.UpdateAsync(carStatus!);

            UpdatedCarStatusResponse response = _mapper.Map<UpdatedCarStatusResponse>(carStatus);
            return response;
        }
    }
}