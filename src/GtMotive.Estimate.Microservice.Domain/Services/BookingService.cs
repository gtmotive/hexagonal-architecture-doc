using System;
using Ardalis.GuardClauses;
using GtMotive.Estimate.Microservice.Domain.Aggregates.CustomerAggregate;
using GtMotive.Estimate.Microservice.Domain.Aggregates.VehicleAggregate;
using GtMotive.Estimate.Microservice.Domain.Exceptions;

// Nota para el revisor: En Clean Architecture se podría pensar en mover esto al
// UseCase, sin embargo, prefiero ser más purista con DDD y mantener el negocio en el dominio,
// en este caso usando un servicio de dominio.
namespace GtMotive.Estimate.Microservice.Domain.Services
{
    /// <summary>
    /// Booking service.
    /// </summary>
    public class BookingService : IBookingService
    {
        /// <summary>
        /// Book a vehicle.
        /// </summary>
        /// <param name="customer">Customer.</param>
        /// <param name="vehicle">Vehicle.</param>
        /// <param name="returnDate">Return date.</param>
        /// <exception cref="VehicleNotAvailableException">VehicleNotAvailableException.</exception>
        public void BookVehicle(Customer customer, Vehicle vehicle, DateOnly returnDate)
        {
            Guard.Against.Null(customer, nameof(customer));
            Guard.Against.Null(vehicle, nameof(vehicle));

            // Nota para el revisor: Esta lógica podría haberse hecho en el agregado Customer
            // al hacer la reserva, pero se ha decidido hacerlo en el servicio para que el agregado
            // Customer no tenga que conocer demasiado sobre el agregado Vehicle.
            if (vehicle.IsAvailable)
            {
                customer.BookVehicle(vehicle.Id, returnDate);
                vehicle.DisableAvailability();
            }
            else
            {
                throw new VehicleNotAvailableException();
            }
        }
    }
}
