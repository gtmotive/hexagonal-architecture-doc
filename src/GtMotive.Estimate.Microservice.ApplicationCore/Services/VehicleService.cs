using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;
using GtMotive.Estimate.Microservice.ApplicationCore.Repositories;
using GtMotive.Estimate.Microservice.Domain.Aggregates;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Services
{
    /// <summary>
    /// Service for managing vehicle-related operations.
    /// </summary>
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleValidationService _vehicleValidationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleService"/> class.
        /// </summary>
        /// <param name="vehicleRepository">The vehicle repository.</param>
        /// <param name="vehicleValidationService">The vehicle validations.</param>
        public VehicleService(IVehicleRepository vehicleRepository, IVehicleValidationService vehicleValidationService)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _vehicleValidationService = vehicleValidationService ?? throw new ArgumentNullException(nameof(vehicleValidationService));
        }

        /// <summary>
        /// Adds a new vehicle to the fleet.
        /// </summary>
        /// <param name="vehicle">The vehicle to be added.</param>
        /// <returns>The added vehicle.</returns>
        public async Task<Vehicle> AddVehicleAsync(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle), "Vehicle cannot be null.");
            }

            if (!_vehicleValidationService.IsVehicleManufacturedWithin5Years(vehicle.ManufactureYear.Value))
            {
                throw new ArgumentException("Vehicle must be manufactured within the last 5 years.", nameof(vehicle));
            }

            await _vehicleRepository.AddAsync(vehicle);
            return vehicle;
        }

        /// <summary>
        /// Retrieves all available vehicles for rent.
        /// </summary>
        /// <returns>The collection of vehicles that are available for rental.</returns>
        public async Task<IEnumerable<Vehicle>> GetAllAvailableVehiclesAsync()
        {
            return await _vehicleRepository.GetAvailableVehiclesAsync();
        }

        /// <summary>
        /// Retrieves a vehicle by its unique identifier.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle.</param>
        /// <returns>The vehicle if found, otherwise null.</returns>
        public async Task<Vehicle> GetVehicleByIdAsync(Guid vehicleId)
        {
            return await _vehicleRepository.GetByIdAsync(vehicleId);
        }

        /// <summary>
        /// Updates a vehicle in the fleet.
        /// </summary>
        /// <param name="vehicle">The vehicle to be updated.</param>
        /// <returns>The updated vehicle.</returns>
        public async Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle)
        {
            // Add business logic and validation here
            await _vehicleRepository.UpdateAsync(vehicle);
            return vehicle;
        }
    }
}
