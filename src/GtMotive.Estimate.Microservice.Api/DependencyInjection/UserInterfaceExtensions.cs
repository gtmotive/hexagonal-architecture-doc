using GtMotive.Estimate.Microservice.Api.Application.CreateFleet;
using GtMotive.Estimate.Microservice.Api.Application.CreateRental;
using GtMotive.Estimate.Microservice.Api.Application.DeleteRental;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateFleet;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateRental;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.DeleteRental;
using GtMotive.Estimate.Microservice.Api.UseCases.GetAllAvailableVehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateFleet;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.DeleteRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllAvailableVehicles;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<CreateFleetPresenter>();
            services.AddScoped<ICreateFleetOutputPort>(x => x.GetRequiredService<CreateFleetPresenter>());
            services.AddScoped<ICreateFleetPresenter>(x => x.GetRequiredService<CreateFleetPresenter>());

            services.AddScoped<CreateVehiclePresenter>();
            services.AddScoped<ICreateVehicleOutputPort>(x => x.GetRequiredService<CreateVehiclePresenter>());
            services.AddScoped<ICreateVehiclePresenter>(x => x.GetRequiredService<CreateVehiclePresenter>());

            services.AddScoped<GetAllAvailableVehiclesPresenter>();
            services.AddScoped<IGetAllAvailableVehiclesOutputPort>(x => x.GetRequiredService<GetAllAvailableVehiclesPresenter>());
            services.AddScoped<IGetAllAvailableVehiclesPresenter>(x => x.GetRequiredService<GetAllAvailableVehiclesPresenter>());

            services.AddScoped<CreateRentalPresenter>();
            services.AddScoped<ICreateRentalOutputPort>(x => x.GetRequiredService<CreateRentalPresenter>());
            services.AddScoped<ICreateRentalPresenter>(x => x.GetRequiredService<CreateRentalPresenter>());

            services.AddScoped<DeleteRentalPresenter>();
            services.AddScoped<IDeleteRentalOutputPort>(x => x.GetRequiredService<DeleteRentalPresenter>());
            services.AddScoped<IDeleteRentalPresenter>(x => x.GetRequiredService<DeleteRentalPresenter>());

            return services;
        }
    }
}
