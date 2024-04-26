using FluentValidation;

namespace Application.Features.Addresses.Commands.Create;

public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressCommandValidator()
    {
        RuleFor(c => c.City).NotEmpty();
        RuleFor(c => c.District).NotEmpty();
        RuleFor(c => c.Street).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
    }
}