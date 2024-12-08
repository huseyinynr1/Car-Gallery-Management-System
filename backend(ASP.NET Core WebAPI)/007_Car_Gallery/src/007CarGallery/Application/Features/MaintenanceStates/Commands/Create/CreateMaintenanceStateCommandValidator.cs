using FluentValidation;

namespace Application.Features.MaintenanceStates.Commands.Create;

public class CreateMaintenanceStateCommandValidator : AbstractValidator<CreateMaintenanceStateCommand>
{
    public CreateMaintenanceStateCommandValidator()
    {
        RuleFor(c => c.State).NotEmpty();
        RuleFor(c => c.SortOrder).NotEmpty();
    }
}