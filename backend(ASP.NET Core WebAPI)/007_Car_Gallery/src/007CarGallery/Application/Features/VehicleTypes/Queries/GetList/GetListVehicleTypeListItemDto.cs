using NArchitecture.Core.Application.Dtos;

namespace Application.Features.VehicleTypes.Queries.GetList;

public class GetListVehicleTypeListItemDto : IDto
{
    public int Id { get; set; }
    public string Type { get; set; }
}