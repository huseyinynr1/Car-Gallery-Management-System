using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaintenanceRecords.Commands.Delete;

public class DeletedMaintenanceRecordResponse : IResponse
{
    public int Id { get; set; }
}