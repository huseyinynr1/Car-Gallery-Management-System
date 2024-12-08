using FluentValidation;

namespace Application.Features.VehicleTypes.Commands.Delete;

public class DeleteVehicleTypeCommandValidator : AbstractValidator<DeleteVehicleTypeCommand>
{
    public DeleteVehicleTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}