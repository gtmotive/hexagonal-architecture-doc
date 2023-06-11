using System;
using GtMotive.Estimate.Microservice.Domain.Aggregates.CustomerAggregate;
using GtMotive.Estimate.Microservice.Domain.Aggregates.VehicleAggregate;

namespace GtMotive.Estimate.Microservice.Domain.Services
{
    /// <summary>
    /// Booking service.
    /// </summary>
    public interface IBookingService
    {
        /// <summary>
        /// Book a vehicle.
        /// </summary>
        /// <param name="customer">Customer.</param>
        /// <param name="vehicle">Vehicle.</param>
        /// <param name="returnDate">Return date.</param>
        /// <exception cref="VehicleNotAvailableException">VehicleNotAvailableException.</exception>
        void BookVehicle(Customer customer, Vehicle vehicle, DateOnly returnDate);
    }
}
