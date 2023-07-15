
using UtilityKit.Components.Nsd.Application.Shared.Delegates;
using UtilityKit.Components.Nsd.Application.Shared.Interfaces;

using UtilityKit.Components.Nsd.Infrastrcuture.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using UtilityKit.Components.Nsd.Infrastrcuture.Migrations.Seed.DataSeeders;
using UtilityKit.Components.Nsd.Application.Contracts.Repository;
using UtilityKit.Components.Nsd.Infrastrcuture.Repositories;

namespace UtilityKit.Components.Nsd.Infrastrcuture
{
    public class Startup : IProjectStartup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void Configure(IServiceProvider provider)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<CSVFileService>();
            services.AddScoped(serviceProvider => AddFileServiceResolver(serviceProvider));
            services.AddMemoryCache();

            #region --- Map Repository with the corresponsing interface
            services.AddScoped<IChartRepository, ChartRepository>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();
            services.AddScoped<IWidgetRepository, WidgetRepository>();
            services.AddScoped<ILayoutCellRepository, LayoutCellRepository>();
            services.AddScoped<IUnitOfWork>(provider => provider.GetService<NsdDbContext>());
            #endregion
        }
        private ServiceResolver<IFileService> AddFileServiceResolver(IServiceProvider serviceProvider)
        {
            return key =>
            {
                switch (key)
                {
                    //case FileServiceNamesConst.CSV:
                    //    return serviceProvider.GetService<CSVFileService>();
                    default:
                        throw new KeyNotFoundException();
                }
            };
        }
    }
}