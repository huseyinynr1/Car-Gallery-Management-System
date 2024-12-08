using Application.Features.MaintenanceStates.Constants;
using Application.Features.MaintenanceStates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaintenanceStates.Constants.MaintenanceStatesOperationClaims;

namespace Application.Features.MaintenanceStates.Commands.Update;

public class UpdateMaintenanceStateCommand : IRequest<UpdatedMaintenanceStateResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public string State { get; set; }
    public int SortOrder { get; set; }

    public string[] Roles => [Admin, Write, MaintenanceStatesOperationClaims.Update];

    public class UpdateMaintenanceStateCommandHandler : IRequestHandler<UpdateMaintenanceStateCommand, UpdatedMaintenanceStateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaintenanceStateRepository _maintenanceStateRepository;
        private readonly MaintenanceStateBusinessRules _maintenanceStateBusinessRules;

        public UpdateMaintenanceStateCommandHandler(IMapper mapper, IMaintenanceStateRepository maintenanceStateRepository,
                                         MaintenanceStateBusinessRules maintenanceStateBusinessRules)
        {
            _mapper = mapper;
            _maintenanceStateRepository = maintenanceStateRepository;
            _maintenanceStateBusinessRules = maintenanceStateBusinessRules;
        }

        public async Task<UpdatedMaintenanceStateResponse> Handle(UpdateMaintenanceStateCommand request, CancellationToken cancellationToken)
        {
            MaintenanceState? maintenanceState = await _maintenanceStateRepository.GetAsync(predicate: ms => ms.Id == request.Id, cancellationToken: cancellationToken);
            await _maintenanceStateBusinessRules.MaintenanceStateShouldExistWhenSelected(maintenanceState);
            maintenanceState = _mapper.Map(request, maintenanceState);

            await _maintenanceStateRepository.UpdateAsync(maintenanceState!);

            UpdatedMaintenanceStateResponse response = _mapper.Map<UpdatedMaintenanceStateResponse>(maintenanceState);
            return response;
        }
    }
}