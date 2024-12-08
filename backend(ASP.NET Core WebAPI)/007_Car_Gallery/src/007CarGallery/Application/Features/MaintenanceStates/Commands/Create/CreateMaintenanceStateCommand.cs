using Application.Features.MaintenanceStates.Constants;
using Application.Features.MaintenanceStates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaintenanceStates.Constants.MaintenanceStatesOperationClaims;

namespace Application.Features.MaintenanceStates.Commands.Create;

public class CreateMaintenanceStateCommand : IRequest<CreatedMaintenanceStateResponse>, ISecuredRequest
{
    public string State { get; set; }
    public int SortOrder { get; set; }

    public string[] Roles => [Admin, Write, MaintenanceStatesOperationClaims.Create];

    public class CreateMaintenanceStateCommandHandler : IRequestHandler<CreateMaintenanceStateCommand, CreatedMaintenanceStateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaintenanceStateRepository _maintenanceStateRepository;
        private readonly MaintenanceStateBusinessRules _maintenanceStateBusinessRules;

        public CreateMaintenanceStateCommandHandler(IMapper mapper, IMaintenanceStateRepository maintenanceStateRepository,
                                         MaintenanceStateBusinessRules maintenanceStateBusinessRules)
        {
            _mapper = mapper;
            _maintenanceStateRepository = maintenanceStateRepository;
            _maintenanceStateBusinessRules = maintenanceStateBusinessRules;
        }

        public async Task<CreatedMaintenanceStateResponse> Handle(CreateMaintenanceStateCommand request, CancellationToken cancellationToken)
        {
            MaintenanceState maintenanceState = _mapper.Map<MaintenanceState>(request);

            await _maintenanceStateRepository.AddAsync(maintenanceState);

            CreatedMaintenanceStateResponse response = _mapper.Map<CreatedMaintenanceStateResponse>(maintenanceState);
            return response;
        }
    }
}