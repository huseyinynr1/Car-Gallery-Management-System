using NArchitecture.Core.Application.Responses;

namespace Application.Features.CarStatusHistories.Commands.Update;

public class UpdatedCarStatusHistoryResponse : IResponse
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int CarStatusId { get; set; }
    public DateTime StatusChange { get; set; }
    public string Remark { get; set; }
}