using FluentValidation;

namespace Application.Features.MaintenanceRecords.Commands.Update;

public class UpdateMaintenanceRecordCommandValidator : AbstractValidator<UpdateMaintenanceRecordCommand>
{
    public UpdateMaintenanceRecordCommandValidator()
    {
        RuleFor(c => c.CarId).NotEmpty();
        RuleFor(c => c.BrandName).NotEmpty();
        RuleFor(c => c.ModelName).NotEmpty();
        RuleFor(c => c.ChassisNo).NotEmpty();
        RuleFor(c => c.Plate).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
        RuleFor(c => c.ComponentCost).NotEmpty();
        RuleFor(c => c.WorkmanshipCost).NotEmpty();
        RuleFor(c => c.ElapsedTime).NotEmpty();
    }
}