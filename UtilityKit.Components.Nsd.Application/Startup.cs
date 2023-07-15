﻿using FluentValidation;
using UtilityKit.Components.Nsd.Application.Shared.Behaviours;
using UtilityKit.Components.Nsd.Application.Shared.Extensions;
using UtilityKit.Components.Nsd.Application.Shared.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UtilityKit.Components.Nsd.Application
{
    public class Startup : IProjectStartup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void Configure(IServiceProvider services)
        {
            services.Seed(typeof(Startup).Assembly);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(Startup).Assembly);


        }
    }
}