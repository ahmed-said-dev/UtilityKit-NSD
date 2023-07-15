using Microsoft.Extensions.DependencyInjection;

namespace UtilityKit.Components.Nsd.Application.Shared.Interfaces
{
    public interface IProjectStartup
    {
        void ConfigureServices(IServiceCollection services);
        void Configure(IServiceProvider provider);
    }
}