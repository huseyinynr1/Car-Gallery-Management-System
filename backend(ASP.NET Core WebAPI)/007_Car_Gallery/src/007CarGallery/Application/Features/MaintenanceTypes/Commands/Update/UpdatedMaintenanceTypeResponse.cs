using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaintenanceTypes.Commands.Update;

public class UpdatedMaintenanceTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Type { get; set; }
    public int SortOrder { get; set; }
}