using GtMotive.Estimate.Microservice.Api.Interfaces;
using GtMotive.Estimate.Microservice.Api.Repository;
using GtMotive.Estimate.Microservice.Infrastructure.FileSystem;
using GtMotive.Estimate.Microservice.Infrastructure.FileSystem.Settings;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddElements(this IServiceCollection services)
        {
            services.AddScoped<FileSystemSettings>();
            services.AddScoped<IFileSystemServices, FileSystemServices>();
            services.AddScoped<IVehicleSystemServices, VehicleSystemServices>();
            services.AddScoped<IRentSystemServices, RentSystemServices>();

            services.AddScoped<IVehicleBusiness, VehicleBusiness>();
            services.AddScoped<IRentBusiness, RentBusiness>();

            return services;
        }
    }
}
