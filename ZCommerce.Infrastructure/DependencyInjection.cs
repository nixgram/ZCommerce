using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZCommerce.Application.Common.Interfaces;
using ZCommerce.Infrastructure.Data;
using ZCommerce.Infrastructure.Models;

namespace ZCommerce.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IApplicationContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();
            return services;
        }
    }
}