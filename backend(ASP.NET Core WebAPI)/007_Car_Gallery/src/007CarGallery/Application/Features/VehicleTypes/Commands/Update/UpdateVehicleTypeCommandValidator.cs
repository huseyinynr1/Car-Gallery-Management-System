using FluentValidation;

namespace Application.Features.VehicleTypes.Commands.Update;

public class UpdateVehicleTypeCommandValidator : AbstractValidator<UpdateVehicleTypeCommand>
{
    public UpdateVehicleTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Type).NotEmpty();
    }
}