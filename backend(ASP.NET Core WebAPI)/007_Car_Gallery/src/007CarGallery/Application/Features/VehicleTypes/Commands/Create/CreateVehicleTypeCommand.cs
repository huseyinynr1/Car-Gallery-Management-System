using Application.Features.VehicleTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.VehicleTypes.Commands.Create;

public class CreateVehicleTypeCommand : IRequest<CreatedVehicleTypeResponse>
{
    public string Type { get; set; }

    public class CreateVehicleTypeCommandHandler : IRequestHandler<CreateVehicleTypeCommand, CreatedVehicleTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly VehicleTypeBusinessRules _vehicleTypeBusinessRules;

        public CreateVehicleTypeCommandHandler(IMapper mapper, IVehicleTypeRepository vehicleTypeRepository,
                                         VehicleTypeBusinessRules vehicleTypeBusinessRules)
        {
            _mapper = mapper;
            _vehicleTypeRepository = vehicleTypeRepository;
            _vehicleTypeBusinessRules = vehicleTypeBusinessRules;
        }

        public async Task<CreatedVehicleTypeResponse> Handle(CreateVehicleTypeCommand request, CancellationToken cancellationToken)
        {
            VehicleType vehicleType = _mapper.Map<VehicleType>(request);

            await _vehicleTypeRepository.AddAsync(vehicleType);

            CreatedVehicleTypeResponse response = _mapper.Map<CreatedVehicleTypeResponse>(vehicleType);
            return response;
        }
    }
}