using NArchitecture.Core.Application.Responses;

namespace Application.Features.CarStatusHistories.Commands.Delete;

public class DeletedCarStatusHistoryResponse : IResponse
{
    public int Id { get; set; }
}