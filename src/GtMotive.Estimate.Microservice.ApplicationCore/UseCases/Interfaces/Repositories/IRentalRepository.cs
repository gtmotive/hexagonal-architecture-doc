using System.Collections.ObjectModel;
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
        /// <param name="clientId">client identify.</param>
        /// <returns>Rentals selected.</returns>
        public Collection<Rental> SelectByClient(int clientId);
    }
}
