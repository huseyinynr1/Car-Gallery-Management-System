using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaintenanceTypes.Commands.Delete;

public class DeletedMaintenanceTypeResponse : IResponse
{
    public int Id { get; set; }
}