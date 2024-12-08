using FluentValidation;

namespace Application.Features.MaintenanceRecords.Commands.Delete;

public class DeleteMaintenanceRecordCommandValidator : AbstractValidator<DeleteMaintenanceRecordCommand>
{
    public DeleteMaintenanceRecordCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}