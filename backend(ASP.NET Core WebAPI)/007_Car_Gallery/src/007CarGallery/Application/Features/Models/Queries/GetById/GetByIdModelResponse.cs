using NArchitecture.Core.Application.Responses;

namespace Application.Features.Models.Queries.GetById;

public class GetByIdModelResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BrandId { get; set; }
}