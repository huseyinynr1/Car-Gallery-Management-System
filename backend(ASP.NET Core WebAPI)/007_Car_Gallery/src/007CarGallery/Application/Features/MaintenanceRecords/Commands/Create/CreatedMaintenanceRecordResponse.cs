using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaintenanceRecords.Commands.Create;

public class CreatedMaintenanceRecordResponse : IResponse
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string BrandName { get; set; }
    public string ModelName { get; set; }
    public string Type { get; set; }
    public string MaintenanceState { get; set; }
    public string MaintenanceType { get; set; }
    public string ChassisNo { get; set; }
    public string Plate { get; set; }
    public string? Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? ComponentCost { get; set; }
    public int? WorkmanshipCost { get; set; }
    public int? DealPrice { get; set; }
    public int? ElapsedTime { get; set; }
}