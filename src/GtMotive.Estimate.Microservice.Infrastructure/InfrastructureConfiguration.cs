using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.ApplicationCore.Contracts.Repositories;
using GtMotive.Estimate.Microservice.Domain.Entities.Auth;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Logging;
using GtMotive.Estimate.Microservice.Infrastructure.Persistence;
using GtMotive.Estimate.Microservice.Infrastructure.Repositories;
using GtMotive.Estimate.Microservice.Infrastructure.Telemetry;
using Microsoft.AspNetCore.Identity;
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

            if (!isDevelopment)
            {
                services.AddScoped(typeof(ITelemetry), typeof(AppTelemetry));
            }
            else
            {
                services.AddScoped(typeof(ITelemetry), typeof(NoOpTelemetry));
            }

            services.AddScoped<RoleManager<Role>>();

            services.AddDbContext<ApiDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: $"ApiDbContext"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<IReservationRepository, ReservationRepository>();

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
