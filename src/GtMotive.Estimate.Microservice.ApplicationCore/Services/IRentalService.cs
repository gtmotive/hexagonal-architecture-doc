using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Services
{
    /// <summary>
    /// Interface for the service handling rental operations.
    /// </summary>
    public interface IRentalService
    {
        /// <summary>
        /// Creates a rental for a vehicle.
        /// </summary>
        /// <param name="rental">Rental data.</param>
        /// <returns>The created rental entity.</returns>
        Task<Rental> CreateRentalAsync(Rental rental);

        /// <summary>
        /// Retrieves a rental by its unique identifier.
        /// </summary>
        /// <param name="rentalId">The unique identifier of the rental.</param>
        /// <returns>The requested rental.</returns>
        Task<Rental> GetRentalByIdAsync(Guid rentalId);

        /// <summary>
        /// Finalizes a rental.
        /// </summary>
        /// <param name="rentalId">The unique identifier of the rental.</param>
        /// <returns>The updated rental information.</returns>
        Task<Rental> ReturnRentalVehicleAsync(Guid rentalId);

        /// <summary>
        /// Retrieves all active rentals.
        /// </summary>
        /// <returns>The collection of active rentals.</returns>
        Task<IEnumerable<Rental>> GetActiveRentals();
    }
}
