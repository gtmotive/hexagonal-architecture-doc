using GtMotive.Estimate.Microservice.Api.UseCases.BookVehicleUseCase;
using GtMotive.Estimate.Microservice.Api.UseCases.GetAllAvailableVehiclesUseCase;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.BookVehicleUseCase;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllAvailableVehiclesUseCase;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<BookVehicleWebApiPresenter>();
            services.AddScoped<IBookVehicleOutputPort>(provider => provider.GetService<BookVehicleWebApiPresenter>());
            services.AddScoped<IBookVehicleWebApiPresenter>(provider => provider.GetService<BookVehicleWebApiPresenter>());

            services.AddScoped<GetAllAvailableVehiclesWebApiPresenter>();
            services.AddScoped<IGetAllAvailableVehiclesOutputPort>(provider => provider.GetService<GetAllAvailableVehiclesWebApiPresenter>());
            services.AddScoped<IGetAllAvailableVehiclesWebApiPresenter>(provider => provider.GetService<GetAllAvailableVehiclesWebApiPresenter>());

            return services;
        }
    }
}
