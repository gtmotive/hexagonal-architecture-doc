using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using GtMotive.Estimate.Microservice.Api.Authorization;
using GtMotive.Estimate.Microservice.Api.DependencyInjection;
using GtMotive.Estimate.Microservice.Api.Filters;
using GtMotive.Estimate.Microservice.ApplicationCore;
using GtMotive.Estimate.Microservice.ApplicationCore.Contracts.Repositories;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Reservation.Commands.CreateReservation;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Reservation.Commands.DeleteReservation;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Commands.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Queries.GetAllReservations;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Queries.GetAllVehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Queries.GetAllVehiclesStates;
using GtMotive.Estimate.Microservice.ApplicationCore.Features.Vehicles.Queries.GetVehicleById;
using GtMotive.Estimate.Microservice.Domain.Entities.Auth;
using GtMotive.Estimate.Microservice.Infrastructure.Persistence;
using GtMotive.Estimate.Microservice.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped(typeof(IVehicleRepository), typeof(VehicleRepository));
            services.AddScoped(typeof(IReservationRepository), typeof(ReservationRepository));
            services.AddMediatR(typeof(GetAllVehiclesQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetVehicleByIdQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateVehicleCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateReservationCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteReservationCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAllReservationsQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAllVehiclesStatesQueryHandler).GetTypeInfo().Assembly);
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<ApiDbContext>().AddDefaultTokenProviders();
            services.AddAuthorization(AuthorizationOptionsExtensions.Configure);
            services.AddUseCases();
            services.AddPresenters();
        }
    }
}
