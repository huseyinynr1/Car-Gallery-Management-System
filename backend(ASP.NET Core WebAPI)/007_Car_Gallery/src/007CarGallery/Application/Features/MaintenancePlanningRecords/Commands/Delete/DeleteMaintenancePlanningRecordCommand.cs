using Application.Features.MaintenancePlanningRecords.Constants;
using Application.Features.MaintenancePlanningRecords.Constants;
using Application.Features.MaintenancePlanningRecords.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaintenancePlanningRecords.Constants.MaintenancePlanningRecordsOperationClaims;

namespace Application.Features.MaintenancePlanningRecords.Commands.Delete;

public class DeleteMaintenancePlanningRecordCommand : IRequest<DeletedMaintenancePlanningRecordResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, MaintenancePlanningRecordsOperationClaims.Delete];

    public class DeleteMaintenancePlanningRecordCommandHandler : IRequestHandler<DeleteMaintenancePlanningRecordCommand, DeletedMaintenancePlanningRecordResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaintenancePlanningRecordRepository _maintenancePlanningRecordRepository;
        private readonly MaintenancePlanningRecordBusinessRules _maintenancePlanningRecordBusinessRules;

        public DeleteMaintenancePlanningRecordCommandHandler(IMapper mapper, IMaintenancePlanningRecordRepository maintenancePlanningRecordRepository,
                                         MaintenancePlanningRecordBusinessRules maintenancePlanningRecordBusinessRules)
        {
            _mapper = mapper;
            _maintenancePlanningRecordRepository = maintenancePlanningRecordRepository;
            _maintenancePlanningRecordBusinessRules = maintenancePlanningRecordBusinessRules;
        }

        public async Task<DeletedMaintenancePlanningRecordResponse> Handle(DeleteMaintenancePlanningRecordCommand request, CancellationToken cancellationToken)
        {
            MaintenancePlanningRecord? maintenancePlanningRecord = await _maintenancePlanningRecordRepository.GetAsync(predicate: mpr => mpr.Id == request.Id, cancellationToken: cancellationToken);
            await _maintenancePlanningRecordBusinessRules.MaintenancePlanningRecordShouldExistWhenSelected(maintenancePlanningRecord);

            await _maintenancePlanningRecordRepository.DeleteAsync(maintenancePlanningRecord!);

            DeletedMaintenancePlanningRecordResponse response = _mapper.Map<DeletedMaintenancePlanningRecordResponse>(maintenancePlanningRecord);
            return response;
        }
    }
}