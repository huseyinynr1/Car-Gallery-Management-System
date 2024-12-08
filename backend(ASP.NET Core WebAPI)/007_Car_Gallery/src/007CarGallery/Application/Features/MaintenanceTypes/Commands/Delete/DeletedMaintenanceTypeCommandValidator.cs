using FluentValidation;

namespace Application.Features.MaintenanceTypes.Commands.Delete;

public class DeleteMaintenanceTypeCommandValidator : AbstractValidator<DeleteMaintenanceTypeCommand>
{
    public DeleteMaintenanceTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}