using Application.Features.MaintenancePlanningRecords.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.MaintenancePlanningRecords.Constants.MaintenancePlanningRecordsOperationClaims;

namespace Application.Features.MaintenancePlanningRecords.Queries.GetList;

public class GetListMaintenancePlanningRecordQuery : IRequest<GetListResponse<GetListMaintenancePlanningRecordListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListMaintenancePlanningRecordQueryHandler : IRequestHandler<GetListMaintenancePlanningRecordQuery, GetListResponse<GetListMaintenancePlanningRecordListItemDto>>
    {
        private readonly IMaintenancePlanningRecordRepository _maintenancePlanningRecordRepository;
        private readonly IMapper _mapper;

        public GetListMaintenancePlanningRecordQueryHandler(IMaintenancePlanningRecordRepository maintenancePlanningRecordRepository, IMapper mapper)
        {
            _maintenancePlanningRecordRepository = maintenancePlanningRecordRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMaintenancePlanningRecordListItemDto>> Handle(GetListMaintenancePlanningRecordQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MaintenancePlanningRecord> maintenancePlanningRecords = await _maintenancePlanningRecordRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMaintenancePlanningRecordListItemDto> response = _mapper.Map<GetListResponse<GetListMaintenancePlanningRecordListItemDto>>(maintenancePlanningRecords);
            return response;
        }
    }
}