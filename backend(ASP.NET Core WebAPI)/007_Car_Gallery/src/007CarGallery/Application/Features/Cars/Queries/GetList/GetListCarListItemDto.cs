using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Cars.Queries.GetList;

public class GetListCarListItemDto : IDto
{
    public int Id { get; set; }
    public string BrandName { get; set; }
    public string ModelName { get; set; }
    public string TransmissionType { get; set; }
    public string FuelType { get; set; }
    public string? Status { get; set; }
    public int? ImageId { get; set; }
    public string ChassisNo { get; set; }
    public string Plate { get; set; }
    public int Kilometer { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }
}