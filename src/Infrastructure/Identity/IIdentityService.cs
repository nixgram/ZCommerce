using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public interface IIdentityService
    {
        Task<bool> IsInRoleAsync(string userId, string role);
        Task<bool> AddRoleToUser(string userId, string role);
    }
}