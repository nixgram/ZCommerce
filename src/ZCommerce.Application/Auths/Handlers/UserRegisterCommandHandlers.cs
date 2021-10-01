using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ZCommerce.Application.Auths.Commands;
using ZCommerce.Application.Auths.Config;
using ZCommerce.Domain.Common;

namespace ZCommerce.Application.Auths.Handlers
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
            var newUser = new ApplicationUser {Email = request.Email, UserName = request.Username,};
            // var res = await _roleManager.CreateAsync(new IdentityRole(Role.Admin));


            var newUserCreatedStatus = await _userManager.CreateAsync(newUser, request.Password);
            // await _userManager.AddToRoleAsync(newUser, Role.Admin);
            if (!newUserCreatedStatus.Succeeded)
                return new AuthResult
                {
                    Errors = newUserCreatedStatus.Errors.Select(x => x.Description).ToList(),
                    Success = false,
                    Token = null
                };

            var jwtToken = Auth.GenerateJwtToken(newUser);
            return new AuthResult
            {
                Errors = null,
                Success = true,
                Token = jwtToken
            };
        }
    }
}