using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Controllers.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Application.Role.Commands;
using Application.Role.Queries;

namespace Api.Controllers
{
    public class RoleController : ApiBaseController
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