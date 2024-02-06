﻿using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.ApplicationCore.Repositories;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.InMemoryData;
using GtMotive.Estimate.Microservice.Infrastructure.InMemoryVehicle;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Logging;
using GtMotive.Estimate.Microservice.Infrastructure.Telemetry;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        [ExcludeFromCodeCoverage]
        public static IInfrastructureBuilder AddBaseInfrastructure(
            this IServiceCollection services,
            bool isDevelopment)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("RentingDb"));
            services.AddScoped<IVehicleRepository, InMemoryVehicleRepository>();
            services.AddScoped<IRentalRepository, InMemoryRentalRepository>();

            if (!isDevelopment)
            {
                services.AddScoped(typeof(ITelemetry), typeof(AppTelemetry));
            }
            else
            {
                services.AddScoped(typeof(ITelemetry), typeof(NoOpTelemetry));
            }

            return new InfrastructureBuilder(services);
        }

        private sealed class InfrastructureBuilder : IInfrastructureBuilder
        {
            public InfrastructureBuilder(IServiceCollection services)
            {
                Services = services;
            }

            public IServiceCollection Services { get; }
        }
    }
}
