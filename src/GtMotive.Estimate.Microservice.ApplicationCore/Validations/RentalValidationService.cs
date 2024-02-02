using System;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Interfaces;
using GtMotive.Estimate.Microservice.ApplicationCore.Repositories;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Validations
{
    /// <summary>
    /// Service responsible for validating if a client can rent a vehicle.
    /// </summary>
    internal class RentalValidationService : IRentalValidationService
    {
        private readonly IRentalRepository _rentalRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalValidationService"/> class.
        /// </summary>
        /// <param name="rentalRepository">The rental repository.</param>
        public RentalValidationService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        /// <summary>
        /// Checks if a client can rent a vehicle.
        /// </summary>
        /// <param name="clientId">The identifier of the client.</param>
        /// <returns>True if the client can rent a vehicle, false otherwise.</returns>
        public async Task<bool> CanClientRentVehicle(Guid clientId)
        {
            var activeRentals = await _rentalRepository.GetActiveRentalsByCustomerId(clientId);
            return !activeRentals.Any();
        }
    }
}
