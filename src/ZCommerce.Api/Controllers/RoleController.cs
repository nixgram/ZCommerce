using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZCommerce.Api.Controllers.Common;
using ZCommerce.Application.Role.Commands;
using ZCommerce.Application.Role.Queries;
using ZCommerce.Domain.Common;

namespace ZCommerce.Api.Controllers
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