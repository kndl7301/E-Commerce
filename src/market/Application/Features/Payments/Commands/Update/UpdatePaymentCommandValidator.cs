using FluentValidation;

namespace Application.Features.Payments.Commands.Update;

public class UpdatePaymentCommandValidator : AbstractValidator<UpdatePaymentCommand>
{
    public UpdatePaymentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CardNumber).NotEmpty();
        RuleFor(c => c.PaymentType).NotEmpty();
        RuleFor(c => c.PaymentDate).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
    }
}