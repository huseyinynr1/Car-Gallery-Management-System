using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaintenanceStates.Commands.Create;

public class CreatedMaintenanceStateResponse : IResponse
{
    public int Id { get; set; }
    public string State { get; set; }
    public int SortOrder { get; set; }
}