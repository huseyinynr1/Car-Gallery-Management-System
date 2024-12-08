using Application.Features.MaintenanceStates.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.MaintenanceStates.Constants.MaintenanceStatesOperationClaims;

namespace Application.Features.MaintenanceStates.Queries.GetList;

public class GetListMaintenanceStateQuery : IRequest<GetListResponse<GetListMaintenanceStateListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListMaintenanceStateQueryHandler : IRequestHandler<GetListMaintenanceStateQuery, GetListResponse<GetListMaintenanceStateListItemDto>>
    {
        private readonly IMaintenanceStateRepository _maintenanceStateRepository;
        private readonly IMapper _mapper;

        public GetListMaintenanceStateQueryHandler(IMaintenanceStateRepository maintenanceStateRepository, IMapper mapper)
        {
            _maintenanceStateRepository = maintenanceStateRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMaintenanceStateListItemDto>> Handle(GetListMaintenanceStateQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MaintenanceState> maintenanceStates = await _maintenanceStateRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMaintenanceStateListItemDto> response = _mapper.Map<GetListResponse<GetListMaintenanceStateListItemDto>>(maintenanceStates);
            return response;
        }
    }
}