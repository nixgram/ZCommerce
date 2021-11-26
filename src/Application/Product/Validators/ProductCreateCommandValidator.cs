using Application.Product.Commands;
using FluentValidation;

namespace Application.Product.Validators
{
    public class ProductCreateCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public ProductCreateCommandValidator()
        {
            RuleFor(p => p.Name).MinimumLength(3);
            RuleFor(p => p.Description).NotNull().MinimumLength(10);
            RuleFor(p => p.Price).NotNull().GreaterThan(0);
            RuleFor(p => p.ProductCategoryId).NotNull().GreaterThan(0);
        }
    }
}