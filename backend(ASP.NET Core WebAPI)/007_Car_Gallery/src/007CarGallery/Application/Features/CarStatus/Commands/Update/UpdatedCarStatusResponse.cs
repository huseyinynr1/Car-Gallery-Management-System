using NArchitecture.Core.Application.Responses;

namespace Application.Features.CarStatus.Commands.Update;

public class UpdatedCarStatusResponse : IResponse
{
    public int Id { get; set; }
    public string Status { get; set; }
}