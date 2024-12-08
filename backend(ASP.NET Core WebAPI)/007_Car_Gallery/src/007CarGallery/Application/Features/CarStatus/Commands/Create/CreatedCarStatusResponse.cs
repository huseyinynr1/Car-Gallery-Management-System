using NArchitecture.Core.Application.Responses;

namespace Application.Features.CarStatus.Commands.Create;

public class CreatedCarStatusResponse : IResponse
{
    public int Id { get; set; }
    public string Status { get; set; }
}