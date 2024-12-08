using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetFilteredCar;
public class GetListFilteredCarListItemDto : IDto
{
    public int Id { get; set; }
    public string? BrandName { get; set; }
    public string? ModelName { get; set; }
    public int? Year { get; set; }
    public double? Price { get; set; }
    public string? TransmissionType { get; set; }
    public string? FuelType { get; set; }
    public string? Status { get; set; }
    public int? Kilometer { get; set; }
    public string Plate { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
