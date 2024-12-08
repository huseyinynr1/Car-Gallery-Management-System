using FluentValidation;

namespace Application.Features.CarStatusHistories.Commands.Update;

public class UpdateCarStatusHistoryCommandValidator : AbstractValidator<UpdateCarStatusHistoryCommand>
{
    public UpdateCarStatusHistoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CarId).NotEmpty();
        RuleFor(c => c.CarStatusId).NotEmpty();
        RuleFor(c => c.StatusChange).NotEmpty();
        RuleFor(c => c.Remark).NotEmpty();
    }
}