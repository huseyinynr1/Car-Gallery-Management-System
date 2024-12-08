using NArchitecture.Core.Application.Responses;

namespace Application.Features.VehicleTypes.Commands.Delete;

public class DeletedVehicleTypeResponse : IResponse
{
    public int Id { get; set; }
}