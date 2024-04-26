using FluentValidation;

namespace Application.Features.Products.Commands.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(c => c.ProductName).NotEmpty();
        RuleFor(c => c.ProductDescription).NotEmpty();
        RuleFor(c => c.ProductImage).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.Stock).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
    }
}