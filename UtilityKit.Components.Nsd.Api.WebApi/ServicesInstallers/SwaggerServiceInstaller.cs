using UtilityKit.Components.Nsd.Application.Shared.Interfaces;

namespace UtilityKit.Components.Nsd.Api.WebApi.ServicesInstallers
{
    public class SwaggerServiceInstaller : IServiceInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration, List<IProjectStartup> projectStartups)
        {
            services.AddSwaggerGen();
        }
    }
}