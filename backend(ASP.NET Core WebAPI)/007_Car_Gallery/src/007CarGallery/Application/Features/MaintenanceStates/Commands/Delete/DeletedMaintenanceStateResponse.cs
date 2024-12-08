using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaintenanceStates.Commands.Delete;

public class DeletedMaintenanceStateResponse : IResponse
{
    public int Id { get; set; }
}