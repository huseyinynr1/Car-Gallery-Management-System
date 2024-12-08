using Application.Features.MaintenanceTypes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.MaintenanceTypes.Constants.MaintenanceTypesOperationClaims;

namespace Application.Features.MaintenanceTypes.Queries.GetList;

public class GetListMaintenanceTypeQuery : IRequest<GetListResponse<GetListMaintenanceTypeListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListMaintenanceTypeQueryHandler : IRequestHandler<GetListMaintenanceTypeQuery, GetListResponse<GetListMaintenanceTypeListItemDto>>
    {
        private readonly IMaintenanceTypeRepository _maintenanceTypeRepository;
        private readonly IMapper _mapper;

        public GetListMaintenanceTypeQueryHandler(IMaintenanceTypeRepository maintenanceTypeRepository, IMapper mapper)
        {
            _maintenanceTypeRepository = maintenanceTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMaintenanceTypeListItemDto>> Handle(GetListMaintenanceTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MaintenanceType> maintenanceTypes = await _maintenanceTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMaintenanceTypeListItemDto> response = _mapper.Map<GetListResponse<GetListMaintenanceTypeListItemDto>>(maintenanceTypes);
            return response;
        }
    }
}