using Application.Features.MaintenanceStates.Constants;
using Application.Features.MaintenanceStates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaintenanceStates.Constants.MaintenanceStatesOperationClaims;

namespace Application.Features.MaintenanceStates.Queries.GetById;

public class GetByIdMaintenanceStateQuery : IRequest<GetByIdMaintenanceStateResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMaintenanceStateQueryHandler : IRequestHandler<GetByIdMaintenanceStateQuery, GetByIdMaintenanceStateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaintenanceStateRepository _maintenanceStateRepository;
        private readonly MaintenanceStateBusinessRules _maintenanceStateBusinessRules;

        public GetByIdMaintenanceStateQueryHandler(IMapper mapper, IMaintenanceStateRepository maintenanceStateRepository, MaintenanceStateBusinessRules maintenanceStateBusinessRules)
        {
            _mapper = mapper;
            _maintenanceStateRepository = maintenanceStateRepository;
            _maintenanceStateBusinessRules = maintenanceStateBusinessRules;
        }

        public async Task<GetByIdMaintenanceStateResponse> Handle(GetByIdMaintenanceStateQuery request, CancellationToken cancellationToken)
        {
            MaintenanceState? maintenanceState = await _maintenanceStateRepository.GetAsync(predicate: ms => ms.Id == request.Id, cancellationToken: cancellationToken);
            await _maintenanceStateBusinessRules.MaintenanceStateShouldExistWhenSelected(maintenanceState);

            GetByIdMaintenanceStateResponse response = _mapper.Map<GetByIdMaintenanceStateResponse>(maintenanceState);
            return response;
        }
    }
}