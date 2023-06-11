using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates.VehicleAggregate;

namespace GtMotive.Estimate.Microservice.Domain.Repositories
{
    /// <summary>
    /// Vehicle repository.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Get Vehicle by id.
        /// </summary>
        /// <param name="id">Vehicle identifier.</param>
        /// <returns>Vehicle.</returns>
        Task<Vehicle> GetAsync(Guid id);

        /// <summary>
        /// Save Vehicle.
        /// </summary>
        /// <param name="vehicle">Vehicle to save.</param>
        /// <returns>Task.</returns>
        Task SaveAsync(Vehicle vehicle);

        /// <summary>
        /// Get all available vehicles.
        /// </summary>
        /// <returns>Vehicles collection.</returns>
        Task<List<Vehicle>> GetAllAvailableVehicles();

        /// <summary>
        /// Delete all vehicles.
        /// </summary>
        /// <returns>Task.</returns>
        Task DeleteAll();
    }
}
