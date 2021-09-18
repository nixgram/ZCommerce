using FluentValidation;
using ZCommerce.Application.Auths.Commands;

namespace ZCommerce.Application.Auths.Validators
{
    public class UserLoginCommandValidator : AbstractValidator<UserLoginCommand>
    {
        public UserLoginCommandValidator()
        {
            RuleFor(p => p.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(p => p.Password).NotNull().NotEmpty().MinimumLength(8);
        }
    }
}