using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZCommerce.Api.Interfaces;
using ZCommerce.Infrastructure;

namespace ZCommerce.Api.Installers
{
    public class InfrastructureInstaller : IInstaller
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddInfrastructure(configuration);
        }
    }
}