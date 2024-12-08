using NArchitecture.Core.Application.Responses;

namespace Application.Features.Fuels.Commands.Create;

public class CreatedFuelResponse : IResponse
{
    public int Id { get; set; }
    public string Type { get; set; }
}