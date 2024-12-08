using NArchitecture.Core.Application.Responses;

namespace Application.Features.Transmissions.Commands.Update;

public class UpdatedTransmissionResponse : IResponse
{
    public int Id { get; set; }
    public string Type { get; set; }
}