using FluentValidation;

namespace Application.Features.CarStatusHistories.Commands.Delete;

public class DeleteCarStatusHistoryCommandValidator : AbstractValidator<DeleteCarStatusHistoryCommand>
{
    public DeleteCarStatusHistoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}