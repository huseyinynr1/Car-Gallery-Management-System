using FluentValidation;

namespace Application.Features.Cars.Commands.Create;

public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(c => c.BrandName).NotEmpty();
        RuleFor(c => c.ModelName).NotEmpty();
        RuleFor(c => c.TransmissionType).NotEmpty();
        RuleFor(c => c.FuelType).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.ChassisNo).NotEmpty();
        RuleFor(c => c.Plate).NotEmpty();
        RuleFor(c => c.Year).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
    }
}