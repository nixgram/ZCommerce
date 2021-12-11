using System.Threading.Tasks;
using Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityService(IAuthorizationService authorizationService,
            IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
            UserManager<ApplicationUser> userManager)
        {
            _authorizationService = authorizationService;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _userManager = userManager;
        }

        public async Task<bool> IsInRoleAsync(string userId, string role)
        {
            var user = await GetApplicationUserByUserId(userId);
            return await _userManager.IsInRoleAsync(user, role);
        }

        public async Task<bool> AddRoleToUser(string userId, string role)
        {
            var user = await GetApplicationUserByUserId(userId);
            if (user is null) return false;

            var isAlreadyRoleAssign = await IsInRoleAsync(user.Id, role);
            if (isAlreadyRoleAssign) return false;

            var assignResult = await _userManager.AddToRoleAsync(user, role);
            return assignResult.Succeeded;
        }


        /*public async Task<string> GetUserRoleByUserId(string userId)
       {
           
           var result = await _userManager.ge
       }*/

        private async Task<ApplicationUser> GetApplicationUserByUserId(string userId)
        {
            return await _userManager.Users.SingleOrDefaultAsync(u => u.Email == userId);
        }
    }
}