using NArchitecture.Core.Application.Responses;

namespace Application.Features.Transmissions.Commands.Create;

public class CreatedTransmissionResponse : IResponse
{
    public int Id { get; set; }
    public string Type { get; set; }
}