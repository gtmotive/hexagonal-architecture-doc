using GtMotive.Estimate.Microservice.Api.Interfaces;
using GtMotive.Estimate.Microservice.Api.Repository;
using GtMotive.Estimate.Microservice.Infrastructure.FileSystem;
using GtMotive.Estimate.Microservice.Infrastructure.FileSystem.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddElements(this IServiceCollection services)
        {
            services.AddScoped<FileSystemSettings>();
            services.AddScoped<FileSystemServices>();

            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IRentRepository, RentRepository>();

            return services;
        }
    }
}
