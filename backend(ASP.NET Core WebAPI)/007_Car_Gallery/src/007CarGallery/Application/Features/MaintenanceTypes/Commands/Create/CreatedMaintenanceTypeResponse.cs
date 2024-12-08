using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaintenanceTypes.Commands.Create;

public class CreatedMaintenanceTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Type { get; set; }
    public int SortOrder { get; set; }
}