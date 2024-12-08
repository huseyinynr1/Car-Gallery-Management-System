using NArchitecture.Core.Application.Responses;

namespace Application.Features.Cars.Commands.Update;

public class UpdatedCarResponse : IResponse
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