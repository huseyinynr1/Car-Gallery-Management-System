using NArchitecture.Core.Application.Responses;

namespace Application.Features.CarStatusHistories.Queries.GetById;

public class GetByIdCarStatusHistoryResponse : IResponse
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int CarStatusId { get; set; }
    public DateTime StatusChange { get; set; }
    public string Remark { get; set; }
}