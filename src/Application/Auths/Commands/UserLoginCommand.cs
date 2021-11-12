using Application.Auths.Config;
using MediatR;

namespace Application.Auths.Commands
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