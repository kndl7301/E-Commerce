using FluentValidation;

namespace Application.Features.Payments.Commands.Create;

public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentCommandValidator()
    {
        RuleFor(c => c.CardNumber).NotEmpty();
        RuleFor(c => c.PaymentType).NotEmpty();
        RuleFor(c => c.PaymentDate).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
    }
}