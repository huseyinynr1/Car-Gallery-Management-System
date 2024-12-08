using NArchitecture.Core.Application.Responses;

namespace Application.Features.Models.Commands.Create;

public class CreatedModelResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BrandId { get; set; }
}