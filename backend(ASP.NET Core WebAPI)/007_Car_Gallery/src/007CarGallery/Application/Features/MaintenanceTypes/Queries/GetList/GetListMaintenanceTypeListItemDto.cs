using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MaintenanceTypes.Queries.GetList;

public class GetListMaintenanceTypeListItemDto : IDto
{
    public int Id { get; set; }
    public string Type { get; set; }
    public int SortOrder { get; set; }
}