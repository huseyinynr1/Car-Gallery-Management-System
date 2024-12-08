using Application.Features.MaintenanceStates.Constants;
using Application.Features.MaintenanceStates.Constants;
using Application.Features.MaintenanceStates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaintenanceStates.Constants.MaintenanceStatesOperationClaims;

namespace Application.Features.MaintenanceStates.Commands.Delete;

public class DeleteMaintenanceStateCommand : IRequest<DeletedMaintenanceStateResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, MaintenanceStatesOperationClaims.Delete];

    public class DeleteMaintenanceStateCommandHandler : IRequestHandler<DeleteMaintenanceStateCommand, DeletedMaintenanceStateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaintenanceStateRepository _maintenanceStateRepository;
        private readonly MaintenanceStateBusinessRules _maintenanceStateBusinessRules;

        public DeleteMaintenanceStateCommandHandler(IMapper mapper, IMaintenanceStateRepository maintenanceStateRepository,
                                         MaintenanceStateBusinessRules maintenanceStateBusinessRules)
        {
            _mapper = mapper;
            _maintenanceStateRepository = maintenanceStateRepository;
            _maintenanceStateBusinessRules = maintenanceStateBusinessRules;
        }

        public async Task<DeletedMaintenanceStateResponse> Handle(DeleteMaintenanceStateCommand request, CancellationToken cancellationToken)
        {
            MaintenanceState? maintenanceState = await _maintenanceStateRepository.GetAsync(predicate: ms => ms.Id == request.Id, cancellationToken: cancellationToken);
            await _maintenanceStateBusinessRules.MaintenanceStateShouldExistWhenSelected(maintenanceState);

            await _maintenanceStateRepository.DeleteAsync(maintenanceState!);

            DeletedMaintenanceStateResponse response = _mapper.Map<DeletedMaintenanceStateResponse>(maintenanceState);
            return response;
        }
    }
}