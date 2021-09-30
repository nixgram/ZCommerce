using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ZCommerce.Application.Common.Interfaces;

namespace ZCommerce.Api.Common
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }
    }
}