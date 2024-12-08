using NArchitecture.Core.Application.Responses;

namespace Application.Features.VehicleTypes.Commands.Create;

public class CreatedVehicleTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Type { get; set; }
}