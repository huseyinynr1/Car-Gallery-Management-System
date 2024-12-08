using NArchitecture.Core.Application.Dtos;

namespace Application.Features.CarStatus.Queries.GetList;

public class GetListCarStatusListItemDto : IDto
{
    public int Id { get; set; }
    public string Status { get; set; }
}