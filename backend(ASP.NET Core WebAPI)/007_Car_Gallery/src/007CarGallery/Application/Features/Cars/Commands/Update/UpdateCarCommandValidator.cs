using FluentValidation;

namespace Application.Features.Cars.Commands.Update;

public class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommand>
{
    public UpdateCarCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BrandName).NotEmpty();
        RuleFor(c => c.ModelName).NotEmpty();
        RuleFor(c => c.TransmissionType).NotEmpty();
        RuleFor(c => c.FuelType).NotEmpty();
        RuleFor(c => c.ChassisNo).NotEmpty();
        RuleFor(c => c.Year).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
    }
}