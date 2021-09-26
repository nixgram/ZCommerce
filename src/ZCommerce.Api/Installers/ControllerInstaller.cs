using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ZCommerce.Api.Interfaces;

namespace ZCommerce.Api.Installers
{
    public class ControllerInstaller : IInstaller
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            // services.AddControllers();
            services.AddResponseCompression();
            services.AddControllers().AddNewtonsoftJson(x =>
                {
                    x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    x.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
                })
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
            services.AddRazorPages();
        }
    }
}