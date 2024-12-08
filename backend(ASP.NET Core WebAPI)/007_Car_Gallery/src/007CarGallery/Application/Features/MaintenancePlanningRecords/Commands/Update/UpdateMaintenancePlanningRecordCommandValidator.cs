using FluentValidation;

namespace Application.Features.MaintenancePlanningRecords.Commands.Update;

public class UpdateMaintenancePlanningRecordCommandValidator : AbstractValidator<UpdateMaintenancePlanningRecordCommand>
{
    public UpdateMaintenancePlanningRecordCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CarId).NotEmpty();
        RuleFor(c => c.BrandName).NotEmpty();
        RuleFor(c => c.ChassisNo).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.Enddate).NotEmpty();
    }
}