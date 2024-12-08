using FluentValidation;

namespace Application.Features.MaintenanceStates.Commands.Delete;

public class DeleteMaintenanceStateCommandValidator : AbstractValidator<DeleteMaintenanceStateCommand>
{
    public DeleteMaintenanceStateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}