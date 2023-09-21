using GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.GetAllAvailableVehicles;
using GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllAvailableVehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using GtMotive.Estimate.Microservice.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddSingleton<MongoService>();
            services.AddSingleton<IVehicleRepository, VehicleRepository>();
            services.AddSingleton<IRentalRepository, RentalRepository>();

            services.AddScoped<CreateVehiclePresenter>();
            services.AddScoped<ICreateVehicleOutputPort>(provider => provider.GetService<CreateVehiclePresenter>());
            services.AddScoped<ICreateVehiclePresenter>(provider => provider.GetService<CreateVehiclePresenter>());

            services.AddScoped<GetAllAvailableVehiclesPresenter>();
            services.AddScoped<IGetAvailableVehiclesOutputPort>(provider => provider.GetService<GetAllAvailableVehiclesPresenter>());
            services.AddScoped<IGetAllAvailableVehiclesPresenter>(provider => provider.GetService<GetAllAvailableVehiclesPresenter>());

            services.AddScoped<RentVehiclePresenter>();
            services.AddScoped<IRentVehicleOutputPort>(provider => provider.GetService<RentVehiclePresenter>());
            services.AddScoped<IRentVehiclePresenter>(provider => provider.GetService<RentVehiclePresenter>());

            services.AddScoped<ReturnVehiclePresenter>();
            services.AddScoped<IReturnVehicleOutputPort>(provider => provider.GetService<ReturnVehiclePresenter>());
            services.AddScoped<IReturnVehiclePresenter>(provider => provider.GetService<ReturnVehiclePresenter>());

            return services;
        }
    }
}
