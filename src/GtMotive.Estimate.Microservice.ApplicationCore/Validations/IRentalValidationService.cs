using System;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Interfaces
{
    /// <summary>
    /// Service responsible for validating if a client can rent a vehicle.
    /// </summary>
    public interface IRentalValidationService
    {
        /// <summary>
        /// Checks if a client can rent a vehicle.
        /// </summary>
        /// <param name="clientId">The identifier of the client.</param>
        /// <returns>True if the client can rent a vehicle, false otherwise.</returns>
        Task<bool> CanClientRentVehicle(Guid clientId);
    }
}
