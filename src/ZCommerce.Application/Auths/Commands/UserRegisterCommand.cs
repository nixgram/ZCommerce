using MediatR;
using ZCommerce.Application.Auths.Config;

namespace ZCommerce.Application.Auths.Commands
{
    public class UserRegisterCommand : IRequest<AuthResult>
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}