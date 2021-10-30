using System.Linq;
using FluentValidation;
using MediatR;
using ZCommerce.Application.Role.Commands;
using ZCommerce.Application.Role.Queries;

namespace ZCommerce.Application.Role.Validators
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator(IMediator mediator)
        {
            RuleFor(p => p.Name).NotNull().NotEmpty().MustAsync(async (name, cancellation) =>
            {
                var getAllRole = await mediator.Send(new GetAllRolesQuery());
                return getAllRole.FirstOrDefault(p => p.Name == name) is null;
            }).WithMessage("This role is already taken");
        }
    }
}