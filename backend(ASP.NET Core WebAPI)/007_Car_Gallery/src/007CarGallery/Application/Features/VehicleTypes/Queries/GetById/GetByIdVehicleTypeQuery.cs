using Application.Features.VehicleTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.VehicleTypes.Queries.GetById;

public class GetByIdVehicleTypeQuery : IRequest<GetByIdVehicleTypeResponse>
{
    public int Id { get; set; }

    public class GetByIdVehicleTypeQueryHandler : IRequestHandler<GetByIdVehicleTypeQuery, GetByIdVehicleTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly VehicleTypeBusinessRules _vehicleTypeBusinessRules;

        public GetByIdVehicleTypeQueryHandler(IMapper mapper, IVehicleTypeRepository vehicleTypeRepository, VehicleTypeBusinessRules vehicleTypeBusinessRules)
        {
            _mapper = mapper;
            _vehicleTypeRepository = vehicleTypeRepository;
            _vehicleTypeBusinessRules = vehicleTypeBusinessRules;
        }

        public async Task<GetByIdVehicleTypeResponse> Handle(GetByIdVehicleTypeQuery request, CancellationToken cancellationToken)
        {
            VehicleType? vehicleType = await _vehicleTypeRepository.GetAsync(predicate: vt => vt.Id == request.Id, cancellationToken: cancellationToken);
            await _vehicleTypeBusinessRules.VehicleTypeShouldExistWhenSelected(vehicleType);

            GetByIdVehicleTypeResponse response = _mapper.Map<GetByIdVehicleTypeResponse>(vehicleType);
            return response;
        }
    }
}