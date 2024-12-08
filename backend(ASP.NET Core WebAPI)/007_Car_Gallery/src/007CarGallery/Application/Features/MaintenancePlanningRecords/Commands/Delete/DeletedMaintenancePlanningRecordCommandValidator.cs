using FluentValidation;

namespace Application.Features.MaintenancePlanningRecords.Commands.Delete;

public class DeleteMaintenancePlanningRecordCommandValidator : AbstractValidator<DeleteMaintenancePlanningRecordCommand>
{
    public DeleteMaintenancePlanningRecordCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}