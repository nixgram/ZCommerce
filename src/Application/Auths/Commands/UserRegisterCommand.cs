using Application.Auths.Config;
using MediatR;

namespace Application.Auths.Commands
{
    public class UserRegisterCommand : IRequest<AuthResult>
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}