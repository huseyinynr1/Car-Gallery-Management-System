using Application.Features.VehicleTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.VehicleTypes.Commands.Update;

public class UpdateVehicleTypeCommand : IRequest<UpdatedVehicleTypeResponse>
{
    public int Id { get; set; }
    public string Type { get; set; }

    public class UpdateVehicleTypeCommandHandler : IRequestHandler<UpdateVehicleTypeCommand, UpdatedVehicleTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly VehicleTypeBusinessRules _vehicleTypeBusinessRules;

        public UpdateVehicleTypeCommandHandler(IMapper mapper, IVehicleTypeRepository vehicleTypeRepository,
                                         VehicleTypeBusinessRules vehicleTypeBusinessRules)
        {
            _mapper = mapper;
            _vehicleTypeRepository = vehicleTypeRepository;
            _vehicleTypeBusinessRules = vehicleTypeBusinessRules;
        }

        public async Task<UpdatedVehicleTypeResponse> Handle(UpdateVehicleTypeCommand request, CancellationToken cancellationToken)
        {
            VehicleType? vehicleType = await _vehicleTypeRepository.GetAsync(predicate: vt => vt.Id == request.Id, cancellationToken: cancellationToken);
            await _vehicleTypeBusinessRules.VehicleTypeShouldExistWhenSelected(vehicleType);
            vehicleType = _mapper.Map(request, vehicleType);

            await _vehicleTypeRepository.UpdateAsync(vehicleType!);

            UpdatedVehicleTypeResponse response = _mapper.Map<UpdatedVehicleTypeResponse>(vehicleType);
            return response;
        }
    }
}