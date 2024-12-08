using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MaintenanceRecords.Queries.GetList;

public class GetListMaintenanceRecordListItemDto : IDto
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int BrandId { get; set; }
    public int ModelId { get; set; }
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