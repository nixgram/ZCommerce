using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ZCommerce.Application.Auths.Commands;
using ZCommerce.Application.Auths.Config;
using ZCommerce.Domain.Common;

namespace ZCommerce.Application.Auths.Handlers
{
    public class UserRegisterCommandHandlers : IRequestHandler<UserRegisterCommand, AuthResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtConfig _config;

        public UserRegisterCommandHandlers(UserManager<ApplicationUser> userManager,
            IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _userManager = userManager;
            _config = optionsMonitor.CurrentValue;
        }

        public async Task<AuthResult> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            var newUser = new ApplicationUser {Email = request.Email, UserName = request.Username};
            var newUserCreatedStatus = await _userManager.CreateAsync(newUser, request.Password);

            if (!newUserCreatedStatus.Succeeded)
                return new AuthResult
                {
                    Errors = newUserCreatedStatus.Errors.Select(x => x.Description).ToList(),
                    Success = false,
                    Token = null
                };

            var jwtToken = GenerateJwtToken(newUser);
            return new AuthResult
            {
                Errors = null,
                Success = true,
                Token = jwtToken
            };
        }


        private string GenerateJwtToken(ApplicationUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("urcjzoSvLeXmkhdUNStgLSLuVgSJSiEr");
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;
        }
    }
}