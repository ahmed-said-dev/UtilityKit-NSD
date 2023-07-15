using UtilityKit.Components.Nsd.Application.Shared.Interfaces;
using UtilityKit.Components.Nsd.Infrastrcuture;
using Microsoft.EntityFrameworkCore;

namespace UtilityKit.Components.Nsd.Api.WebApi.ServicesInstallers
{
    public class DBServiceInstaller : IServiceInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration, List<IProjectStartup> projectStartups)
        {
            services.AddDbContext<NsdDbContext>(options =>
                options.UseNpgsql(configuration.GetValue<string>("DBSettigs:ConnectionString")));
        }
    }
}
