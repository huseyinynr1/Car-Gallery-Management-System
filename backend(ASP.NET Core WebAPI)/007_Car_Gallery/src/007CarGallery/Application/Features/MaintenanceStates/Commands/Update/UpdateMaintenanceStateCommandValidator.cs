using FluentValidation;

namespace Application.Features.MaintenanceStates.Commands.Update;

public class UpdateMaintenanceStateCommandValidator : AbstractValidator<UpdateMaintenanceStateCommand>
{
    public UpdateMaintenanceStateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.State).NotEmpty();
        RuleFor(c => c.SortOrder).NotEmpty();
    }
}