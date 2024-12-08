using FluentValidation;

namespace Application.Features.MaintenancePlanningRecords.Commands.Create;

public class CreateMaintenancePlanningRecordCommandValidator : AbstractValidator<CreateMaintenancePlanningRecordCommand>
{
    public CreateMaintenancePlanningRecordCommandValidator()
    {
        RuleFor(c => c.CarId).NotEmpty();
        RuleFor(c => c.BrandName).NotEmpty();
        RuleFor(c => c.ChassisNo).NotEmpty();
        RuleFor(c => c.Plate).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.Enddate).NotEmpty();
        RuleFor(c => c.EstimatedElapsedTime).NotEmpty();
        RuleFor(c => c.EstimatedCost).NotEmpty();
        RuleFor(c => c.EstimatedComponentCost).NotEmpty();
        RuleFor(c => c.EstimatedWorkmanshipCost).NotEmpty();
    }
}