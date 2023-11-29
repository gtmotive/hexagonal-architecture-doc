using GtMotive.Estimate.Microservice.Api.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class MapperInterfaceExtensions
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            MapperVehicleConfig.Initialize();
            MapperRentConfig.Initialize();
            return services;
        }
    }
}
