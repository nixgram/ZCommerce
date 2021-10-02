using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ZCommerce.Domain.Common;

namespace ZCommerce.Application.Role.Commands
{
    public class CreateRoleCommand : IRequest<OneOf.OneOf<ErrorDescriptor, bool>>
    {
        public string Name { get; set; }

        public CreateRoleCommand(string name)
        {
            Name = name;
        }
    }


    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, OneOf.OneOf<ErrorDescriptor, bool>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateRoleCommandHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<OneOf.OneOf<ErrorDescriptor, bool>> Handle(CreateRoleCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var isRoleExist = await _roleManager.FindByNameAsync(request.Name);
                if (isRoleExist != null)
                {
                    return new ErrorDescriptor()
                    {
                        CauseOfError = "This name is already taken",
                        ExceptionMessage = null,
                        ExtraNoteForResolve = "Try with another name"
                    };
                }


                var result = await _roleManager.CreateAsync(new IdentityRole(request.Name));

                return result.Succeeded;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new ErrorDescriptor
                {
                    ExceptionMessage = e.Message,
                    CauseOfError = "Something wrong happens during creation",
                    ExtraNoteForResolve = "Try again to create this role"
                };
            }
        }
    }
}