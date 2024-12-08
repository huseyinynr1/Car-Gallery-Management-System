using NArchitecture.Core.Application.Responses;

namespace Application.Features.VehicleTypes.Queries.GetById;

public class GetByIdVehicleTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Type { get; set; }
}