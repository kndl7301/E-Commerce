using FluentValidation;

namespace Application.Features.Products.Commands.Update;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProductName).NotEmpty();
        RuleFor(c => c.ProductDescription).NotEmpty();
        RuleFor(c => c.ProductImage).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.Stock).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
    }
}