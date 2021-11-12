using Application.Auths.Commands;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Domain.Common;

namespace Application.Auths.Validators
{
    public class UserRegisterCommandValidator : AbstractValidator<UserRegisterCommand>
    {
        public UserRegisterCommandValidator(UserManager<ApplicationUser> userManager)
        {
            RuleFor(p => p.Email).NotNull().EmailAddress();
            RuleFor(p => p.Email).MustAsync(async (email, cancellation) =>
            {
                var existingEmail = await userManager.FindByEmailAsync(email);
                return existingEmail is null;
            }).WithMessage("Email is already in use.");
            RuleFor(p => p.Password).NotNull().NotEmpty().MinimumLength(8);
        }
    }
}