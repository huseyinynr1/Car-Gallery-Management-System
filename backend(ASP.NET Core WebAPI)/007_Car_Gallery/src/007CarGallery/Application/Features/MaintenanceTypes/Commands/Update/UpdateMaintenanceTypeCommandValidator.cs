using FluentValidation;

namespace Application.Features.MaintenanceTypes.Commands.Update;

public class UpdateMaintenanceTypeCommandValidator : AbstractValidator<UpdateMaintenanceTypeCommand>
{
    public UpdateMaintenanceTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.SortOrder).NotEmpty();
    }
}