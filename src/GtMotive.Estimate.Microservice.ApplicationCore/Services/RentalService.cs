using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;
using GtMotive.Estimate.Microservice.ApplicationCore.Repositories;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Services
{
    /// <summary>
    /// Service for managing rental-related operations.
    /// </summary>
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IRentalValidationService _rentalValidationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalService"/> class.
        /// </summary>
        /// <param name="rentalRepository">The rental repository.</param>
        /// <param name="vehicleRepository">The vehicle repository.</param>
        /// <param name="rentalValidationService">The rental validation service.</param>
        public RentalService(IRentalRepository rentalRepository, IVehicleRepository vehicleRepository, IRentalValidationService rentalValidationService)
        {
            _rentalRepository = rentalRepository ?? throw new ArgumentNullException(nameof(rentalRepository));
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _rentalValidationService = rentalValidationService ?? throw new ArgumentNullException(nameof(rentalValidationService));
        }

        /// <summary>
        /// Completes a rental.
        /// </summary>
        /// <param name="rentalId">The ID of the rental to complete.</param>
        /// <returns>The updated rental.</returns>
        public async Task<Rental> ReturnRentalVehicleAsync(Guid rentalId)
        {
            var rental = await _rentalRepository.GetByIdAsync(rentalId) ?? throw new InvalidOperationException("Rental not found.");
            var vehicle = await _vehicleRepository.GetByIdAsync(rental.VehicleId) ?? throw new InvalidOperationException("Vehicle not found.");

            if (!rental.IsActive)
            {
                throw new ArgumentException("The rental car has already been returned.");
            }

            rental.CompleteRental(DateTime.Now);
            vehicle.Return();
            await _rentalRepository.UpdateAsync(rental);
            await _vehicleRepository.UpdateAsync(vehicle);
            return rental;
        }

        /// <summary>
        /// Creates a rental for a vehicle.
        /// </summary>
        /// <param name="rental">The rental to be created.</param>
        /// <returns>The created rental entity.</returns>
        public async Task<Rental> CreateRentalAsync(Rental rental)
        {
            if (rental == null)
            {
                throw new ArgumentNullException(nameof(rental));
            }

            if (!await _rentalValidationService.CanClientRentVehicle(rental.CustomerId))
            {
                throw new InvalidOperationException("This customer already has an active rental.");
            }

            var vehicle = await _vehicleRepository.GetByIdAsync(rental.VehicleId);
            if (vehicle == null || !vehicle.IsAvailable)
            {
                throw new InvalidOperationException("Vehicle is not available for rental.");
            }

            await _rentalRepository.AddAsync(rental);

            vehicle.Rent();
            await _vehicleRepository.UpdateAsync(vehicle);

            return rental;
        }

        /// <summary>
        /// Retrieves a rental by its unique identifier.
        /// </summary>
        /// <param name="rentalId">The ID of the rental.</param>
        /// <returns>The rental if found, otherwise null.</returns>
        public async Task<Rental> GetRentalByIdAsync(Guid rentalId)
        {
            return await _rentalRepository.GetByIdAsync(rentalId);
        }

        /// <summary>
        /// Retrieves all active rentals.
        /// </summary>
        /// <returns>The collection of active rentals.</returns>
        public async Task<IEnumerable<Rental>> GetActiveRentals()
        {
            return await _rentalRepository.GetActiveRentals();
        }
    }
}
