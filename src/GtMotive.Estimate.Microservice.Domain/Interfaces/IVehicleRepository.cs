using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Represents an interface for a repository responsible for managing vehicle data.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Retrieves a vehicle by its unique identifier.
        /// </summary>
        /// <param name="vehicleId">The unique identifier of the vehicle to retrieve.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, returning the retrieved vehicle.</returns>
        Task<Vehicle> GetVehicleById(Guid vehicleId);

        /// <summary>
        /// Retrieves a list of all available vehicles within a specified fleet.
        /// </summary>
        /// <param name="fleetId">The unique identifier of the fleet to retrieve available vehicles from.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, returning a list of available vehicles.</returns>
        Task<List<Vehicle>> GetAllAvailableVehicles(Guid fleetId);

        /// <summary>
        /// Adds a new vehicle to the repository.
        /// </summary>
        /// <param name="vehicle">The vehicle to be added.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, returning the added vehicle.</returns>
        Task<Vehicle> AddVehicle(Vehicle vehicle);

        /// <summary>
        /// Modifies the rental status of a vehicle identified by its unique identifier.
        /// </summary>
        /// <param name="vehicleId">The unique identifier of the vehicle to modify.</param>
        /// <param name="isRental">A boolean value indicating whether the vehicle is being rented.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task ModifyVehicleRental(Guid vehicleId, bool isRental);
    }
}
