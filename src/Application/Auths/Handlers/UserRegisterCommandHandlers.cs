using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Auths.Commands;
using Application.Auths.Config;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Domain.Common;

namespace Application.Auths.Handlers
{
    public class UserRegisterCommandHandlers : IRequestHandler<UserRegisterCommand, AuthResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        // ReSharper disable once NotAccessedField.Local
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRegisterCommandHandlers(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<AuthResult> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            var newUser = new ApplicationUser {Email = request.Email, UserName = request.Username};

            var allRoles = await _roleManager.GetRoleNameAsync(new IdentityRole(request.RoleName));

            if (string.IsNullOrEmpty(allRoles))
            {
                await _roleManager.CreateAsync(new IdentityRole(request.RoleName));
            }

            var newUserCreatedStatus = await _userManager.CreateAsync(newUser, request.Password);
            await _userManager.AddToRoleAsync(newUser, request.RoleName);
            if (!newUserCreatedStatus.Succeeded)
                return new AuthResult
                {
                    Errors = newUserCreatedStatus.Errors.Select(x => x.Description).ToList(),
                    Success = false,
                    Token = null
                };

            var jwtToken = Auth.GenerateJwtToken(newUser, request.RoleName);
            return new AuthResult
            {
                Errors = null,
                Success = true,
                Token = jwtToken
            };
        }
    }
}