using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZCommerce.Api.Common;
using ZCommerce.Api.Interfaces;
using ZCommerce.Application.Common.Interfaces;

namespace ZCommerce.Api.Installers
{
    public class CurrentUserInstaller : IInstaller
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
        }
    }
}