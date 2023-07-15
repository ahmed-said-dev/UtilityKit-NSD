using UtilityKit.Components.Nsd.Application.Shared.Interfaces;
namespace UtilityKit.Components.Nsd.Api.WebApi.ServicesInstallers;
public class ControllerServiceInstaller : IServiceInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration, List<IProjectStartup> projectStartups)
    {
        services.AddControllers().AddNewtonsoftJson();
        services.AddEndpointsApiExplorer();
    }
}