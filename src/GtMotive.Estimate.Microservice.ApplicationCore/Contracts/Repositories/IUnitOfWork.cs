using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Common;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Contracts.Repositories
{
    /// <summary>
    /// IUnitOfWork.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets vehicleRepository.
        /// </summary>
        IVehicleRepository VehicleRepository { get; }

        /// <summary>
        /// Gets reservation repository.
        /// </summary>
        IReservationRepository ReservationRepository { get; }

        /// <summary>
        /// Repository.
        /// </summary>
        /// <typeparam name="TEntity">TEntity.</typeparam>
        /// <returns>Return TEntity.</returns>
        IAsyncRepository<TEntity> Repository<TEntity>()
            where TEntity : BaseDomainModel;

        /// <summary>
        /// Complete.
        /// </summary>
        /// <returns>int.</returns>
        Task<int> Complete();
    }
}
