using NArchitecture.Core.Application.Responses;

namespace Application.Features.MaintenancePlanningRecords.Commands.Delete;

public class DeletedMaintenancePlanningRecordResponse : IResponse
{
    public int Id { get; set; }
}