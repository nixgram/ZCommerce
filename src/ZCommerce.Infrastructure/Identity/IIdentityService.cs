using System.Threading.Tasks;

namespace ZCommerce.Infrastructure.Identity
{
    public interface IIdentityService
    {
        Task<bool> IsInRoleAsync(string userId, string role);
    }
}