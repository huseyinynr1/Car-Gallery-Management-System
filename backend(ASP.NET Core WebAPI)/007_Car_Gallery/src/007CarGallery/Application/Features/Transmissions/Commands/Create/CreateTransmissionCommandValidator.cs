using FluentValidation;

namespace Application.Features.Transmissions.Commands.Create;

public class CreateTransmissionCommandValidator : AbstractValidator<CreateTransmissionCommand>
{
    public CreateTransmissionCommandValidator()
    {
        RuleFor(c => c.Type).NotEmpty();
    }
}