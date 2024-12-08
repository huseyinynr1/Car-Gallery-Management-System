using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.VehicleTypes.Queries.GetList;

public class GetListVehicleTypeQuery : IRequest<GetListResponse<GetListVehicleTypeListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListVehicleTypeQueryHandler : IRequestHandler<GetListVehicleTypeQuery, GetListResponse<GetListVehicleTypeListItemDto>>
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IMapper _mapper;

        public GetListVehicleTypeQueryHandler(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListVehicleTypeListItemDto>> Handle(GetListVehicleTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<VehicleType> vehicleTypes = await _vehicleTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListVehicleTypeListItemDto> response = _mapper.Map<GetListResponse<GetListVehicleTypeListItemDto>>(vehicleTypes);
            return response;
        }
    }
}