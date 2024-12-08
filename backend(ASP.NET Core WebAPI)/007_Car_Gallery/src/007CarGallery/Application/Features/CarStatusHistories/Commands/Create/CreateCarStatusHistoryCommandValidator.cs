using FluentValidation;

namespace Application.Features.CarStatusHistories.Commands.Create;

public class CreateCarStatusHistoryCommandValidator : AbstractValidator<CreateCarStatusHistoryCommand>
{
    public CreateCarStatusHistoryCommandValidator()
    {
        RuleFor(c => c.CarId).NotEmpty();
        RuleFor(c => c.CarStatusId).NotEmpty();
        RuleFor(c => c.StatusChange).NotEmpty();
        RuleFor(c => c.Remark).NotEmpty();
    }
}