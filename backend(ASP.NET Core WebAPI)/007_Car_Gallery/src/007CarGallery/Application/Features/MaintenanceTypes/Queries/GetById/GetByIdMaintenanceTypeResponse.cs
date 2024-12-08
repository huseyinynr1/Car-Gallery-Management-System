using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaintenanceTypes.Queries.GetById;

public class GetByIdMaintenanceTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Type { get; set; }
    public int SortOrder { get; set; }
}