using NArchitecture.Core.Application.Dtos;

namespace Application.Features.CarStatusHistories.Queries.GetList;

public class GetListCarStatusHistoryListItemDto : IDto
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int CarStatusId { get; set; }
    public DateTime StatusChange { get; set; }
    public string Remark { get; set; }
}