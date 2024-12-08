using Application.Features.MaintenanceTypes.Constants;
using Application.Features.MaintenanceTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaintenanceTypes.Constants.MaintenanceTypesOperationClaims;

namespace Application.Features.MaintenanceTypes.Queries.GetById;

public class GetByIdMaintenanceTypeQuery : IRequest<GetByIdMaintenanceTypeResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMaintenanceTypeQueryHandler : IRequestHandler<GetByIdMaintenanceTypeQuery, GetByIdMaintenanceTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaintenanceTypeRepository _maintenanceTypeRepository;
        private readonly MaintenanceTypeBusinessRules _maintenanceTypeBusinessRules;

        public GetByIdMaintenanceTypeQueryHandler(IMapper mapper, IMaintenanceTypeRepository maintenanceTypeRepository, MaintenanceTypeBusinessRules maintenanceTypeBusinessRules)
        {
            _mapper = mapper;
            _maintenanceTypeRepository = maintenanceTypeRepository;
            _maintenanceTypeBusinessRules = maintenanceTypeBusinessRules;
        }

        public async Task<GetByIdMaintenanceTypeResponse> Handle(GetByIdMaintenanceTypeQuery request, CancellationToken cancellationToken)
        {
            MaintenanceType? maintenanceType = await _maintenanceTypeRepository.GetAsync(predicate: mt => mt.Id == request.Id, cancellationToken: cancellationToken);
            await _maintenanceTypeBusinessRules.MaintenanceTypeShouldExistWhenSelected(maintenanceType);

            GetByIdMaintenanceTypeResponse response = _mapper.Map<GetByIdMaintenanceTypeResponse>(maintenanceType);
            return response;
        }
    }
}