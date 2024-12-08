using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaintenanceStates.Queries.GetById;

public class GetByIdMaintenanceStateResponse : IResponse
{
    public int Id { get; set; }
    public string State { get; set; }
    public int SortOrder { get; set; }
}