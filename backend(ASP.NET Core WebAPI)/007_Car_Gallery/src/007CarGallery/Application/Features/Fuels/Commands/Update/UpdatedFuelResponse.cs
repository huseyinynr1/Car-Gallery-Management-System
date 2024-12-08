using NArchitecture.Core.Application.Responses;

namespace Application.Features.Fuels.Commands.Update;

public class UpdatedFuelResponse : IResponse
{
    public int Id { get; set; }
    public string Type { get; set; }
}