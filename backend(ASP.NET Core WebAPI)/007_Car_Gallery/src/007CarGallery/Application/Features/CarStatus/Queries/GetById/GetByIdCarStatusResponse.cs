using NArchitecture.Core.Application.Responses;

namespace Application.Features.CarStatus.Queries.GetById;

public class GetByIdCarStatusResponse : IResponse
{
    public int Id { get; set; }
    public string Status { get; set; }
}