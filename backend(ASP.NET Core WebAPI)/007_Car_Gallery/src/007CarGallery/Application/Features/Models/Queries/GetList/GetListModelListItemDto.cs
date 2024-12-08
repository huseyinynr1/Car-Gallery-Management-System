using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Models.Queries.GetList;

public class GetListModelListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BrandId { get; set; }
}