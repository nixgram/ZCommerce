using Application.ProductCategory.Commands;
using FluentValidation;

namespace Application.ProductCategory.Validators
{
    public class CreteProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
    {
        public CreteProductCategoryCommandValidator()
        {
            RuleFor(p => p.Description).NotNull().NotEmpty().MinimumLength(10);
            RuleFor(p => p.Name).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(p => p.ImageUrl).NotNull();
            RuleFor(p => p.LogoUrl).NotNull();
        }
    }
}