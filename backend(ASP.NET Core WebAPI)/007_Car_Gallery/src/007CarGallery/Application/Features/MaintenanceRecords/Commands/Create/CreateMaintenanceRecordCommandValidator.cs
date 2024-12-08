using FluentValidation;

namespace Application.Features.MaintenanceRecords.Commands.Create;

public class CreateMaintenanceRecordCommandValidator : AbstractValidator<CreateMaintenanceRecordCommand>
{
    public CreateMaintenanceRecordCommandValidator()
    {
        RuleFor(c => c.CarId).NotEmpty();
        RuleFor(c => c.BrandName).NotEmpty();
        RuleFor(c => c.ModelName).NotEmpty();
        RuleFor(c => c.ChassisNo).NotEmpty();
        RuleFor(c => c.Plate).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
    }
}