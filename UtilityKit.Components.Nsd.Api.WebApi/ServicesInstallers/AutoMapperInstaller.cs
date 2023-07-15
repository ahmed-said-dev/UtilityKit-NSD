﻿using AutoMapper;
using UtilityKit.Components.Nsd.Application.Mappings;
using UtilityKit.Components.Nsd.Application.Shared.Interfaces;

namespace UtilityKit.Components.Nsd.Api.WebApi.ServicesInstallers
{
    public class AutoMapperInstaller : IServiceInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration, List<IProjectStartup> projectStartups)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
