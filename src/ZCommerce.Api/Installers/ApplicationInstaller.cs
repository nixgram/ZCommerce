using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZCommerce.Api.Interfaces;
using ZCommerce.Application;

namespace ZCommerce.Api.Installers
{
    public class ApplicationInstaller : IInstaller
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddApplication(configuration);
        }
    }
}