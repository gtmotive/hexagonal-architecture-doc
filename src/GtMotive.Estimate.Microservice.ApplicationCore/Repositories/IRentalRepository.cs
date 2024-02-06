using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Repositories
{
    /// <summary>
    /// Interface for the rental repository handling data operations for Rental entities.
    /// </summary>
    public interface IRentalRepository
    {
        /// <summary>
        /// Retrieves a rental by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the rental.</param>
        /// <returns>The rental if found; otherwise, null.</returns>
        Task<Rental> GetByIdAsync(Guid id);

        /// <summary>
        /// Retrieves all rentals for a specific customer.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer.</param>
        /// <returns>A collection of rentals for the specified customer.</returns>
        Task<IEnumerable<Rental>> GetByCustomerIdAsync(Guid customerId);

        /// <summary>
        /// Adds a new rental to the repository.
        /// </summary>
        /// <param name="rental">The rental to add.</param>
        /// <returns>Task.</returns>
        Task AddAsync(Rental rental);

        /// <summary>
        /// Updates a rental in the repository.
        /// </summary>
        /// <param name="rental">The rental to update.</param>
        /// <returns>Task.</returns>
        Task UpdateAsync(Rental rental);

        /// <summary>
        /// Retrieves all active rentals for a specific customer.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer.</param>
        /// <returns>A collection of active rentals for the specified customer.</returns>
        Task<IEnumerable<Rental>> GetActiveRentalsByCustomerId(Guid customerId);

        /// <summary>
        /// Retrieves all active rentals.
        /// </summary>
        /// <returns>The collection of active rentals.</returns>
        Task<IEnumerable<Rental>> GetActiveRentals();
    }
}
