using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MaintenancePlanningRecords.Queries.GetList;

public class GetListMaintenancePlanningRecordListItemDto : IDto
{
    public int Id { get; set; }
    public int? CarId { get; set; }
    public int? BrandId { get; set; }
    public int ModelId { get; set; }
    public string ChassisNo { get; set; }
    public string Plate { get; set; }
    public string? Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? EstimatedElapsedTime { get; set; }
    public int? EstimatedCost { get; set; }
    public int? EstimatedComponentCost { get; set; }
    public int? EstimatedWorkmanshipCost { get; set; }
}