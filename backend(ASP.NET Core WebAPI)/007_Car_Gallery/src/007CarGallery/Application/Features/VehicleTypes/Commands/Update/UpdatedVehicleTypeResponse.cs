using NArchitecture.Core.Application.Responses;

namespace Application.Features.VehicleTypes.Commands.Update;

public class UpdatedVehicleTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Type { get; set; }
}