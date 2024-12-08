using FluentValidation;

namespace Application.Features.VehicleTypes.Commands.Create;

public class CreateVehicleTypeCommandValidator : AbstractValidator<CreateVehicleTypeCommand>
{
    public CreateVehicleTypeCommandValidator()
    {
        RuleFor(c => c.Type).NotEmpty();
    }
}