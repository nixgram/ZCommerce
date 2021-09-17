using System.Security.Claims;
using InvoiceManagementApp.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace InvoiceManagementApp.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }
    }
}