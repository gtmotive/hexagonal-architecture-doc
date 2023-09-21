using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Represents an interface for a repository responsible for managing rental data.
    /// </summary>
    public interface IRentalRepository
    {
        /// <summary>
        /// Retrieves a rental by its unique identifier.
        /// </summary>
        /// <param name="rentalId">The unique identifier of the rental to retrieve.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, returning the retrieved rental.</returns>
        Task<Rental> GetRentalById(Guid rentalId);

        /// <summary>
        /// Adds a new rental to the repository.
        /// </summary>
        /// <param name="rental">The rental to be added.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, returning the added rental.</returns>
        Task<Rental> AddRental(Rental rental);

        /// <summary>
        /// Marks a rental as completed, given its unique identifier.
        /// </summary>
        /// <param name="rentalId">The unique identifier of the rental to be completed.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task CompleteRental(Guid rentalId);

        /// <summary>
        /// Checks if a client has an active rental based on their identification card.
        /// </summary>
        /// <param name="clientId">The identification card of the client to check.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, returning a boolean value indicating the presence of an active rental.</returns>
        Task<bool> HasActiveRental(string clientId);
    }
}
