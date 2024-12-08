using NArchitecture.Core.Application.Responses;

namespace Application.Features.Models.Commands.Update;

public class UpdatedModelResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BrandId { get; set; }
}