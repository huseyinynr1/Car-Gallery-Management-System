using Application.Features.MaintenanceTypes.Constants;
using Application.Features.MaintenanceTypes.Constants;
using Application.Features.MaintenanceTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaintenanceTypes.Constants.MaintenanceTypesOperationClaims;

namespace Application.Features.MaintenanceTypes.Commands.Delete;

public class DeleteMaintenanceTypeCommand : IRequest<DeletedMaintenanceTypeResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, MaintenanceTypesOperationClaims.Delete];

    public class DeleteMaintenanceTypeCommandHandler : IRequestHandler<DeleteMaintenanceTypeCommand, DeletedMaintenanceTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaintenanceTypeRepository _maintenanceTypeRepository;
        private readonly MaintenanceTypeBusinessRules _maintenanceTypeBusinessRules;

        public DeleteMaintenanceTypeCommandHandler(IMapper mapper, IMaintenanceTypeRepository maintenanceTypeRepository,
                                         MaintenanceTypeBusinessRules maintenanceTypeBusinessRules)
        {
            _mapper = mapper;
            _maintenanceTypeRepository = maintenanceTypeRepository;
            _maintenanceTypeBusinessRules = maintenanceTypeBusinessRules;
        }

        public async Task<DeletedMaintenanceTypeResponse> Handle(DeleteMaintenanceTypeCommand request, CancellationToken cancellationToken)
        {
            MaintenanceType? maintenanceType = await _maintenanceTypeRepository.GetAsync(predicate: mt => mt.Id == request.Id, cancellationToken: cancellationToken);
            await _maintenanceTypeBusinessRules.MaintenanceTypeShouldExistWhenSelected(maintenanceType);

            await _maintenanceTypeRepository.DeleteAsync(maintenanceType!);

            DeletedMaintenanceTypeResponse response = _mapper.Map<DeletedMaintenanceTypeResponse>(maintenanceType);
            return response;
        }
    }
}