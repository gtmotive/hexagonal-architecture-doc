using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Repositories;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Interfaces.Repositories
{
    /// <summary>
    /// Rental Repository.
    /// </summary>
    public interface IRentalRepository
        : IRepository<Rental>
    {
        /// <summary>
        /// Select Rent by vehicle and client.
        /// </summary>
        /// <param name="vehicleId">Vehicle identify.</param>
        /// <param name="clientId">Client identify.</param>
        /// <returns>Rental selected.</returns>
        public Rental SelectByVehicleClient(int vehicleId, int clientId);
    }
}
