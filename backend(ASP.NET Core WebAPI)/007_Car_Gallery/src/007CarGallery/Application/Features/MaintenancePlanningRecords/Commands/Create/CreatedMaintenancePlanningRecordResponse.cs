using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaintenancePlanningRecords.Commands.Create;

public class CreatedMaintenancePlanningRecordResponse : IResponse
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string BrandName { get; set; }
    public string ModelName { get; set; }
    public string Type { get; set; }
    public string MaintenanceState { get; set; }
    public string MaintenanceType {get; set;}
    public string ChassisNo { get; set; }
    public string Plate { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime Enddate { get; set; }
    public int EstimatedElapsedTime { get; set; }
    public int? EstimatedCost { get; set; }
    public int? EstimatedComponentCost { get; set; }
    public int? EstimatedWorkmanshipCost { get; set; }
}