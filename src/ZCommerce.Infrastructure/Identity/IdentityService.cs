using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ZCommerce.Domain.Common;

namespace ZCommerce.Infrastructure.Identity
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
            var user = _userManager.Users.SingleOrDefault(u => u.Email == userId);
            return await _userManager.IsInRoleAsync(user, role);
        }
    }
}