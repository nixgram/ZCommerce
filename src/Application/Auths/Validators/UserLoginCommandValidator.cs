using Application.Auths.Commands;
using FluentValidation;

namespace Application.Auths.Validators
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