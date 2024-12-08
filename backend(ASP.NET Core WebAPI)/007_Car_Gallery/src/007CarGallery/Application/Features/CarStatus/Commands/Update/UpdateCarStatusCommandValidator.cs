using FluentValidation;

namespace Application.Features.CarStatus.Commands.Update;

public class UpdateCarStatusCommandValidator : AbstractValidator<UpdateCarStatusCommand>
{
    public UpdateCarStatusCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
    }
}