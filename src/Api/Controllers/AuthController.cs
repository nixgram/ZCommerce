using System.Threading.Tasks;
using Api.Controllers.Common;
using Application.Auths.Commands;
using Application.Auths.Config;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class AuthController : ApiBaseControllerV1
    {
        [HttpPost("register")]
        public async Task<ActionResult<AuthResult>> Register(UserRegisterCommand userRegisterCommand)
        {
            return await Mediator.Send(userRegisterCommand);
        }

        [HttpPost("login")]
        public async Task<AuthResult> Login(UserLoginCommand userLoginCommand)
        {
            return await Mediator.Send(userLoginCommand);
        }
    }
}