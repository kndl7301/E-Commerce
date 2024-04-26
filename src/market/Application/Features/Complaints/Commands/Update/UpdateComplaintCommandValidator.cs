using FluentValidation;

namespace Application.Features.Complaints.Commands.Update;

public class UpdateComplaintCommandValidator : AbstractValidator<UpdateComplaintCommand>
{
    public UpdateComplaintCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.ComplaintText).NotEmpty();
        RuleFor(c => c.ComplaintDate).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.CustomerEmail).NotEmpty();
    }
}