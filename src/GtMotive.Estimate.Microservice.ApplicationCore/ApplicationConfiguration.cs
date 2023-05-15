﻿using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateFleet;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.DeleteRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAllAvailableVehicles;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.ApplicationCore
{
    /// <summary>
    /// Adds Use Cases classes.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ApplicationConfiguration
    {
        /// <summary>
        /// Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICreateFleetUseCase, CreateFleetUseCase>();
            services.AddScoped<ICreateVehicleUseCase, CreateVehicleUseCase>();
            services.AddScoped<IGetAllAvailableVehiclesUseCase, GetAllAvailableVehiclesUseCase>();
            services.AddScoped<ICreateRentalUseCase, CreateRentalUseCase>();
            services.AddScoped<IDeleteRentalUseCase, DeleteRentalUseCase>();

            return services;
        }
    }
}
