using NArchitecture.Core.Application.Responses;

namespace Application.Features.Transmissions.Queries.GetById;

public class GetByIdTransmissionResponse : IResponse
{
    public int Id { get; set; }
    public string Type { get; set; }
}