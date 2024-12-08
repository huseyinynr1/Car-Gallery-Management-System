using FluentValidation;

namespace Application.Features.CarStatus.Commands.Delete;

public class DeleteCarStatusCommandValidator : AbstractValidator<DeleteCarStatusCommand>
{
    public DeleteCarStatusCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}