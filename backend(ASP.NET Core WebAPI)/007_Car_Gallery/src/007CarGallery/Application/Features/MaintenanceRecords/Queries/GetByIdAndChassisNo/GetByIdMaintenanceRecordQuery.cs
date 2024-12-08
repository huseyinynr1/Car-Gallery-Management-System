using Application.Features.MaintenanceRecords.Constants;
using Application.Features.MaintenanceRecords.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.MaintenanceRecords.Constants.MaintenanceRecordsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.MaintenanceRecords.Queries.GetById;

public class GetByIdMaintenanceRecordQuery : IRequest<GetByIdMaintenanceRecordResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public string ChassisNo { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdMaintenanceRecordQueryHandler : IRequestHandler<GetByIdMaintenanceRecordQuery, GetByIdMaintenanceRecordResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;
        private readonly MaintenanceRecordBusinessRules _maintenanceRecordBusinessRules;

        public GetByIdMaintenanceRecordQueryHandler(IMapper mapper, IMaintenanceRecordRepository maintenanceRecordRepository, MaintenanceRecordBusinessRules maintenanceRecordBusinessRules)
        {
            _mapper = mapper;
            _maintenanceRecordRepository = maintenanceRecordRepository;
            _maintenanceRecordBusinessRules = maintenanceRecordBusinessRules;
        }

        public async Task<GetByIdMaintenanceRecordResponse> Handle(GetByIdMaintenanceRecordQuery request, CancellationToken cancellationToken)
        {
            MaintenanceRecord? maintenanceRecord = await _maintenanceRecordRepository.GetAsync(predicate: mr => mr.Id == request.Id && mr.ChassisNo == request.ChassisNo,
                include : mr => mr.Include(mr => mr.Brand)
                                  .Include(mr => mr.Model)
                                  .Include(mr => mr.MaintenanceState)
                                  .Include(mr => mr.MaintenanceType),
                cancellationToken: cancellationToken);
            await _maintenanceRecordBusinessRules.MaintenanceRecordShouldExistWhenSelected(maintenanceRecord);

            GetByIdMaintenanceRecordResponse response = _mapper.Map<GetByIdMaintenanceRecordResponse>(maintenanceRecord);
            return response;
        }
    }
}