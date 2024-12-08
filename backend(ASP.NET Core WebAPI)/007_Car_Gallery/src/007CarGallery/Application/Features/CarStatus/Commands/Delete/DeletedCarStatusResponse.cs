using NArchitecture.Core.Application.Responses;

namespace Application.Features.CarStatus.Commands.Delete;

public class DeletedCarStatusResponse : IResponse
{
    public int Id { get; set; }
}