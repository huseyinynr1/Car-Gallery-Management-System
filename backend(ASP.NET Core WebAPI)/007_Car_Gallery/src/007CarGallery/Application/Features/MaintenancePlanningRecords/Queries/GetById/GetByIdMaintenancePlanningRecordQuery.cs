using Application.Features.MaintenancePlanningRecords.Constants;
using Application.Features.MaintenancePlanningRecords.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaintenancePlanningRecords.Constants.MaintenancePlanningRecordsOperationClaims;

namespace Application.Features.MaintenancePlanningRecords.Queries.GetById;

public class GetByIdMaintenancePlanningRecordQuery : IRequest<GetByIdMaintenancePlanningRecordResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMaintenancePlanningRecordQueryHandler : IRequestHandler<GetByIdMaintenancePlanningRecordQuery, GetByIdMaintenancePlanningRecordResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaintenancePlanningRecordRepository _maintenancePlanningRecordRepository;
        private readonly MaintenancePlanningRecordBusinessRules _maintenancePlanningRecordBusinessRules;

        public GetByIdMaintenancePlanningRecordQueryHandler(IMapper mapper, IMaintenancePlanningRecordRepository maintenancePlanningRecordRepository, MaintenancePlanningRecordBusinessRules maintenancePlanningRecordBusinessRules)
        {
            _mapper = mapper;
            _maintenancePlanningRecordRepository = maintenancePlanningRecordRepository;
            _maintenancePlanningRecordBusinessRules = maintenancePlanningRecordBusinessRules;
        }

        public async Task<GetByIdMaintenancePlanningRecordResponse> Handle(GetByIdMaintenancePlanningRecordQuery request, CancellationToken cancellationToken)
        {
            MaintenancePlanningRecord? maintenancePlanningRecord = await _maintenancePlanningRecordRepository.GetAsync(predicate: mpr => mpr.Id == request.Id, cancellationToken: cancellationToken);
            await _maintenancePlanningRecordBusinessRules.MaintenancePlanningRecordShouldExistWhenSelected(maintenancePlanningRecord);

            GetByIdMaintenancePlanningRecordResponse response = _mapper.Map<GetByIdMaintenancePlanningRecordResponse>(maintenancePlanningRecord);
            return response;
        }
    }
}