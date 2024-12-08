using Application.Features.MaintenanceRecords.Constants;
using Application.Features.MaintenanceRecords.Constants;
using Application.Features.MaintenanceRecords.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaintenanceRecords.Constants.MaintenanceRecordsOperationClaims;

namespace Application.Features.MaintenanceRecords.Commands.Delete;

public class DeleteMaintenanceRecordCommand : IRequest<DeletedMaintenanceRecordResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, MaintenanceRecordsOperationClaims.Delete];

    public class DeleteMaintenanceRecordCommandHandler : IRequestHandler<DeleteMaintenanceRecordCommand, DeletedMaintenanceRecordResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;
        private readonly MaintenanceRecordBusinessRules _maintenanceRecordBusinessRules;

        public DeleteMaintenanceRecordCommandHandler(IMapper mapper, IMaintenanceRecordRepository maintenanceRecordRepository,
                                         MaintenanceRecordBusinessRules maintenanceRecordBusinessRules)
        {
            _mapper = mapper;
            _maintenanceRecordRepository = maintenanceRecordRepository;
            _maintenanceRecordBusinessRules = maintenanceRecordBusinessRules;
        }

        public async Task<DeletedMaintenanceRecordResponse> Handle(DeleteMaintenanceRecordCommand request, CancellationToken cancellationToken)
        {
            MaintenanceRecord? maintenanceRecord = await _maintenanceRecordRepository.GetAsync(predicate: mr => mr.Id == request.Id, cancellationToken: cancellationToken);
            await _maintenanceRecordBusinessRules.MaintenanceRecordShouldExistWhenSelected(maintenanceRecord);

            await _maintenanceRecordRepository.DeleteAsync(maintenanceRecord!);

            DeletedMaintenanceRecordResponse response = _mapper.Map<DeletedMaintenanceRecordResponse>(maintenanceRecord);
            return response;
        }
    }
}