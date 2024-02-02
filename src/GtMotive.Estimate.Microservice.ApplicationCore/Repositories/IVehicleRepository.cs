using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Repositories
{
    /// <summary>
    /// Interface for the vehicle repository handling data operations for Vehicle entities.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Retrieves a vehicle by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the vehicle.</param>
        /// <returns>The vehicle if found; otherwise, null.</returns>
        Task<Vehicle> GetByIdAsync(Guid id);

        /// <summary>
        /// Retrieves all vehicles.
        /// </summary>
        /// <returns>A collection of all vehicles.</returns>
        Task<IEnumerable<Vehicle>> GetAllAsync();

        /// <summary>
        /// Adds a new vehicle to the repository.
        /// </summary>
        /// <param name="vehicle">The vehicle to add.</param>
        /// <returns>Task.</returns>
        Task AddAsync(Vehicle vehicle);

        /// <summary>
        /// Updates a vehicle in the repository.
        /// </summary>
        /// <param name="vehicle">The vehicle to update.</param>
        /// <returns>Task.</returns>
        Task UpdateAsync(Vehicle vehicle);

        /// <summary>
        /// Retrieves all available vehicles for rent.
        /// </summary>
        /// <returns>The collection of vehicles that are available for rental.</returns>
        Task<IEnumerable<Vehicle>> GetAvailableVehiclesAsync();
    }
}
