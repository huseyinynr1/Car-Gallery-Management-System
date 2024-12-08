using Application.Features.CarStatus.Constants;
using Application.Features.CarStatus.Constants;
using Application.Features.CarStatus.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CarStatus.Constants.CarStatusOperationClaims;

namespace Application.Features.CarStatus.Commands.Delete;

public class DeleteCarStatusCommand : IRequest<DeletedCarStatusResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, CarStatusOperationClaims.Delete];

    public class DeleteCarStatusCommandHandler : IRequestHandler<DeleteCarStatusCommand, DeletedCarStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarStatusRepository _carStatusRepository;
        private readonly CarStatusBusinessRules _carStatusBusinessRules;

        public DeleteCarStatusCommandHandler(IMapper mapper, ICarStatusRepository carStatusRepository,
                                         CarStatusBusinessRules carStatusBusinessRules)
        {
            _mapper = mapper;
            _carStatusRepository = carStatusRepository;
            _carStatusBusinessRules = carStatusBusinessRules;
        }

        public async Task<DeletedCarStatusResponse> Handle(DeleteCarStatusCommand request, CancellationToken cancellationToken)
        {
            CarStatusEntity? carStatus = await _carStatusRepository.GetAsync(predicate: cs => cs.Id == request.Id, cancellationToken: cancellationToken);
            await _carStatusBusinessRules.CarStatusShouldExistWhenSelected(carStatus);

            await _carStatusRepository.DeleteAsync(carStatus!);

            DeletedCarStatusResponse response = _mapper.Map<DeletedCarStatusResponse>(carStatus);
            return response;
        }
    }
}