using Application.Features.MaintenanceRecords.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.MaintenanceRecords.Constants.MaintenanceRecordsOperationClaims;

namespace Application.Features.MaintenanceRecords.Queries.GetList;

public class GetListMaintenanceRecordQuery : IRequest<GetListResponse<GetListMaintenanceRecordListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListMaintenanceRecordQueryHandler : IRequestHandler<GetListMaintenanceRecordQuery, GetListResponse<GetListMaintenanceRecordListItemDto>>
    {
        private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;
        private readonly IMapper _mapper;

        public GetListMaintenanceRecordQueryHandler(IMaintenanceRecordRepository maintenanceRecordRepository, IMapper mapper)
        {
            _maintenanceRecordRepository = maintenanceRecordRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMaintenanceRecordListItemDto>> Handle(GetListMaintenanceRecordQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MaintenanceRecord> maintenanceRecords = await _maintenanceRecordRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMaintenanceRecordListItemDto> response = _mapper.Map<GetListResponse<GetListMaintenanceRecordListItemDto>>(maintenanceRecords);
            return response;
        }
    }
}