using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Auths.Commands;
using Application.Auths.Config;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Auths.Handlers
{
    public class UserLoginCommandHandlers : IRequestHandler<UserLoginCommand, AuthResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserLoginCommandHandlers(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AuthResult> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var userCredentials = await _userManager.FindByEmailAsync(request.Email);
            if (userCredentials is null)
                return new AuthResult {Errors = new List<string> {"Invalid Login Request."}, Success = false};

            var isCorrectPassword = await _userManager.CheckPasswordAsync(userCredentials, request.Password);

            if (!isCorrectPassword)
                return new AuthResult {Errors = new List<string> {"Email or Password is wrong."}, Success = false};


            var role = await _userManager.GetRolesAsync(userCredentials);

            // TODO : get role or default anonymous will be passed by GenerateJWTToken
            var jwtToken = Auth.GenerateJwtToken(userCredentials, role.FirstOrDefault());
            return new AuthResult
            {
                Token = jwtToken,
                Errors = null,
                Success = true
            };
        }
    }
}