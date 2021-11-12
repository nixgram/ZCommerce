using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Auths.Commands;
using Application.Auths.Config;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Domain.Common;

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

            var jwtToken = Auth.GenerateJwtToken(userCredentials);
            return new AuthResult
            {
                Token = jwtToken,
                Errors = null,
                Success = true
            };
        }
    }
}