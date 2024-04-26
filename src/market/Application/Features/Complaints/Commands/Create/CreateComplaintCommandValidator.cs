using FluentValidation;

namespace Application.Features.Complaints.Commands.Create;

public class CreateComplaintCommandValidator : AbstractValidator<CreateComplaintCommand>
{
    public CreateComplaintCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.ComplaintText).NotEmpty();
        RuleFor(c => c.ComplaintDate).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.CustomerEmail).NotEmpty();
    }
}