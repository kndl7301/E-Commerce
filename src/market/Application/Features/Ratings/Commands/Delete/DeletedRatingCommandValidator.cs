using FluentValidation;

namespace Application.Features.Ratings.Commands.Delete;

public class DeleteRatingCommandValidator : AbstractValidator<DeleteRatingCommand>
{
    public DeleteRatingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}