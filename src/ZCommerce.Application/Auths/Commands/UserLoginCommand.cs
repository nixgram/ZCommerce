using MediatR;
using ZCommerce.Application.Auths.Config;

namespace ZCommerce.Application.Auths.Commands
{
    public class UserLoginCommand : IRequest<AuthResult>
    {
        public UserLoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}