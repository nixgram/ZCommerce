using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZCommerce.Api.Interfaces;

namespace ZCommerce.Api.Installers
{
    public class ControllerInstaller : IInstaller
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddControllers();
            services.AddRazorPages();
        }
    }
}