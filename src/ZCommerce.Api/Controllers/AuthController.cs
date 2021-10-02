using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZCommerce.Api.Controllers.Common;
using ZCommerce.Application.Auths.Commands;
using ZCommerce.Application.Auths.Config;

namespace ZCommerce.Api.Controllers
{
    public class AuthController : ApiBaseController
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