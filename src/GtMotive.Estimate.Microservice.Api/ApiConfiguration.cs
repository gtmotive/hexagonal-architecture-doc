using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using GtMotive.Estimate.Microservice.Api.Authorization;
using GtMotive.Estimate.Microservice.Api.DependencyInjection;
using GtMotive.Estimate.Microservice.Api.Filters;
using GtMotive.Estimate.Microservice.ApplicationCore;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Implementation;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces.Repositories;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories;
using GtMotive.Estimate.Microservice.Infrastructure.Repositories;
using GtMotive.Estimate.Microservice.Infrastructure.SqlServer.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.Api
{
    [ExcludeFromCodeCoverage]
    public static class ApiConfiguration
    {
        public static void ConfigureControllers(MvcOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            options.Filters.Add<BusinessExceptionFilter>();
        }

        public static IMvcBuilder WithApiControllers(this IMvcBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddApplicationPart(typeof(ApiConfiguration).GetTypeInfo().Assembly);

            AddApiDependencies(builder.Services);

            return builder;
        }

        public static void AddApiDependencies(this IServiceCollection services)
        {
            services.AddAuthorization(AuthorizationOptionsExtensions.Configure);
            services.AddMediatR(typeof(ApiConfiguration).GetTypeInfo().Assembly);
            services.AddUseCases();
            services.AddPresenters();
            services.AddDbContext<RentingContext>();

            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IRentalService, RentalService>();

            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IRentalRepository, RentalRepository>();
        }
    }
}
