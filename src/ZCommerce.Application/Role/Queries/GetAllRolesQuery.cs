using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ZCommerce.Application.Role.Queries
{
    public class GetAllRolesQuery : IRequest<List<IdentityRole>>
    {
    }

    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<IdentityRole>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public GetAllRolesQueryHandler(RoleManager<IdentityRole> roleManager) => _roleManager = roleManager;

        public async Task<List<IdentityRole>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
            => await _roleManager.Roles.ToListAsync(cancellationToken: cancellationToken);
    }
}