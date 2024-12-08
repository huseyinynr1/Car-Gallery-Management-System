using Application.Features.VehicleTypes.Constants;
using Application.Features.VehicleTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.VehicleTypes.Commands.Delete;

public class DeleteVehicleTypeCommand : IRequest<DeletedVehicleTypeResponse>
{
    public int Id { get; set; }

    public class DeleteVehicleTypeCommandHandler : IRequestHandler<DeleteVehicleTypeCommand, DeletedVehicleTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly VehicleTypeBusinessRules _vehicleTypeBusinessRules;

        public DeleteVehicleTypeCommandHandler(IMapper mapper, IVehicleTypeRepository vehicleTypeRepository,
                                         VehicleTypeBusinessRules vehicleTypeBusinessRules)
        {
            _mapper = mapper;
            _vehicleTypeRepository = vehicleTypeRepository;
            _vehicleTypeBusinessRules = vehicleTypeBusinessRules;
        }

        public async Task<DeletedVehicleTypeResponse> Handle(DeleteVehicleTypeCommand request, CancellationToken cancellationToken)
        {
            VehicleType? vehicleType = await _vehicleTypeRepository.GetAsync(predicate: vt => vt.Id == request.Id, cancellationToken: cancellationToken);
            await _vehicleTypeBusinessRules.VehicleTypeShouldExistWhenSelected(vehicleType);

            await _vehicleTypeRepository.DeleteAsync(vehicleType!);

            DeletedVehicleTypeResponse response = _mapper.Map<DeletedVehicleTypeResponse>(vehicleType);
            return response;
        }
    }
}