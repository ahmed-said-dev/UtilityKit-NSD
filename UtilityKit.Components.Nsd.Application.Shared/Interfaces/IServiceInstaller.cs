using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UtilityKit.Components.Nsd.Application.Shared.Interfaces
{
    public interface IServiceInstaller
    {
        void InstallService(IServiceCollection services, IConfiguration configuration, List<IProjectStartup> projectStartups);
    }
}
