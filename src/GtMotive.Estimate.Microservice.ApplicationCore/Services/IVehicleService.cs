using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Services
{
    /// <summary>
    /// Interface for the service handling vehicle operations.
    /// </summary>
    public interface IVehicleService
    {
        /// <summary>
        /// Adds a new vehicle to the fleet.
        /// </summary>
        /// <param name="vehicle">Vehicle data.</param>
        /// <returns>The added vehicle entity.</returns>
        Task<Vehicle> AddVehicleAsync(Vehicle vehicle);

        /// <summary>
        /// Retrieves all available vehicles for rent.
        /// </summary>
        /// <returns>The collection of vehicles that are available for rental.</returns>
        Task<IEnumerable<Vehicle>> GetAllAvailableVehiclesAsync();

        /// <summary>
        /// Retrieves a vehicle by its unique identifier.
        /// </summary>
        /// <param name="vehicleId">The unique identifier of the vehicle.</param>
        /// <returns>The requested vehicle.</returns>
        Task<Vehicle> GetVehicleByIdAsync(Guid vehicleId);

        /// <summary>
        /// Updates a vehicle in the fleet.
        /// </summary>
        /// <param name="vehicle">Vehicle data.</param>
        /// <returns>The updated vehicle entity.</returns>
        Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle);
    }
}
