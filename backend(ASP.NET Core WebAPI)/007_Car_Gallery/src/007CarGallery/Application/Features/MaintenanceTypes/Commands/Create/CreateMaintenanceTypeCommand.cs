using Application.Features.MaintenanceTypes.Constants;
using Application.Features.MaintenanceTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaintenanceTypes.Constants.MaintenanceTypesOperationClaims;

namespace Application.Features.MaintenanceTypes.Commands.Create;

public class CreateMaintenanceTypeCommand : IRequest<CreatedMaintenanceTypeResponse>, ISecuredRequest
{
    public string Type { get; set; }
    public int SortOrder { get; set; }

    public string[] Roles => [Admin, Write, MaintenanceTypesOperationClaims.Create];

    public class CreateMaintenanceTypeCommandHandler : IRequestHandler<CreateMaintenanceTypeCommand, CreatedMaintenanceTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaintenanceTypeRepository _maintenanceTypeRepository;
        private readonly MaintenanceTypeBusinessRules _maintenanceTypeBusinessRules;

        public CreateMaintenanceTypeCommandHandler(IMapper mapper, IMaintenanceTypeRepository maintenanceTypeRepository,
                                         MaintenanceTypeBusinessRules maintenanceTypeBusinessRules)
        {
            _mapper = mapper;
            _maintenanceTypeRepository = maintenanceTypeRepository;
            _maintenanceTypeBusinessRules = maintenanceTypeBusinessRules;
        }

        public async Task<CreatedMaintenanceTypeResponse> Handle(CreateMaintenanceTypeCommand request, CancellationToken cancellationToken)
        {
            MaintenanceType maintenanceType = _mapper.Map<MaintenanceType>(request);

            await _maintenanceTypeRepository.AddAsync(maintenanceType);

            CreatedMaintenanceTypeResponse response = _mapper.Map<CreatedMaintenanceTypeResponse>(maintenanceType);
            return response;
        }
    }
}