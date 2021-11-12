using System;
using System.Linq;
using Api.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions
{
    public static class InstallersExtension
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            typeof(Startup).Assembly.ExportedTypes.Where(installer => typeof(IInstaller)
                    .IsAssignableFrom(installer) & !installer.IsInterface && !installer.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList()
                .ForEach(installer => installer.InstallServices(configuration, services));
        }
    }
}