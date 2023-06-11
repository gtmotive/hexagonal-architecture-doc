using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.Domain
{
    /// <summary>
    /// Adds Use Cases classes.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class DomainConfiguration
    {
        /// <summary>
        /// Adds domain services to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IBookingService, BookingService>();

            return services;
        }
    }
}
