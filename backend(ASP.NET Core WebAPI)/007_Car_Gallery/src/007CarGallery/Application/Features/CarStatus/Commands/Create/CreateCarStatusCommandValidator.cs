using FluentValidation;

namespace Application.Features.CarStatus.Commands.Create;

public class CreateCarStatusCommandValidator : AbstractValidator<CreateCarStatusCommand>
{
    public CreateCarStatusCommandValidator()
    {
        RuleFor(c => c.Status).NotEmpty();
    }
}