using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Controllers.Common;
using Application.Role.Commands;
using Application.Role.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
   
    public class RoleController : ApiBaseControllerV1
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateRoleCommand roleCommand)
        {
            var result = await Mediator.Send(roleCommand);
            return result.Match(
                descriptor => Ok(descriptor),
                b => Ok(b));
        }

        [HttpGet]
        public async Task<List<IdentityRole>> Get() => await Mediator.Send(new GetAllRolesQuery());
    }
}