using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MaintenanceStates.Queries.GetList;

public class GetListMaintenanceStateListItemDto : IDto
{
    public int Id { get; set; }
    public string State { get; set; }
    public int SortOrder { get; set; }
}