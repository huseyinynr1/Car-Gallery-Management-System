using NArchitecture.Core.Application.Responses;

namespace Application.Features.Cars.Queries.GetById;

public class GetByIdCarResponse : IResponse
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public int ModelId { get; set; }
    public int TransmissionId { get; set; }
    public int FuelId { get; set; }
    public int? StatusId { get; set; }
    public int? ImageId { get; set; }
    public string ChassisNo { get; set; }
    public string Plate { get; set; }
    public int Kilometer { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }
}