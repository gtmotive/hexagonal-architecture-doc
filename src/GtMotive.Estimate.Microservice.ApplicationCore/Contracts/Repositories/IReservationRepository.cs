using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Contracts.Repositories
{
    /// <summary>
    /// IReservationRepository.
    /// </summary>
    public interface IReservationRepository : IAsyncRepository<Reservation>
    {
        /// <summary>
        /// GetReservationsByUserId.
        /// </summary>
        /// <param name="id">User Id.</param>
        /// <returns>List Reservation.</returns>
        public Task<List<Reservation>> GetReservationsByUserIdAsync(Guid id);

        /// <summary>
        /// GetAllReservationsInfo.
        /// </summary>
        /// <returns>List Reservation.</returns>
        public Task<List<Reservation>> GetAllReservationsInfoAsync();
    }
}
