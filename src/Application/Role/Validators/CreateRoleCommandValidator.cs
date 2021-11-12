using System.Linq;
using Application.Role.Commands;
using Application.Role.Queries;
using FluentValidation;
using MediatR;

namespace Application.Role.Validators
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