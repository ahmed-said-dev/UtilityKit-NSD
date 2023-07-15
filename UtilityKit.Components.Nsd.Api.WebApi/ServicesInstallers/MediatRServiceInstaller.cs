using UtilityKit.Components.Nsd.Application.Shared.Interfaces;
using MediatR;

namespace UtilityKit.Components.Nsd.Api.WebApi.ServicesInstallers
{
    public class MediatRServiceInstaller : IServiceInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration, List<IProjectStartup> projectStartups)
        {
            services.AddMediatR(projectStartups.Select(startup => startup.GetType().Assembly).ToArray());
        }
    }
}