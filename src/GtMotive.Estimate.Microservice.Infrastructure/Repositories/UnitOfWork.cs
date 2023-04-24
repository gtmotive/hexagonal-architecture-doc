using System;
using System.Collections;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Contracts.Repositories;
using GtMotive.Estimate.Microservice.Domain.Common;
using GtMotive.Estimate.Microservice.Infrastructure.Persistence;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    /// <summary>
    /// UnitOfWork.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// _vehicleRepository.
        /// </summary>
        private IVehicleRepository _vehicleRepository;

        /// <summary>
        /// _reservationRepository.
        /// </summary>
        private IReservationRepository _reservationRepository;
        private Hashtable _repositories;
        private bool isDisposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// Constructor (context DI).
        /// </summary>
        /// <param name="context">ApiDbContext.</param>
        public UnitOfWork(ApiDbContext context)
        {
            ApiDbContext = context;
            ApiDbContext.Database.EnsureCreated();
        }

        /// <summary>
        /// Gets get context method.
        /// </summary>
        public ApiDbContext ApiDbContext { get; }

        /// <summary>
        /// Gets vehicleRepository.
        /// </summary>
        public IVehicleRepository VehicleRepository => _vehicleRepository ??= new VehicleRepository(ApiDbContext);

        /// <summary>
        /// Gets ReservationRepository.
        /// </summary>
        public IReservationRepository ReservationRepository => _reservationRepository ??= new ReservationRepository(ApiDbContext);

        /// <summary>
        /// Transactions confirmation.
        /// </summary>
        /// <returns>int.</returns>
        public async Task<int> Complete()
        {
            return await ApiDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Repositories instances creation.
        /// </summary>
        /// <typeparam name="TEntity">T Entity.</typeparam>
        /// <returns>TEntity.</returns>
        public IAsyncRepository<TEntity> Repository<TEntity>()
            where TEntity : BaseDomainModel
        {
            _repositories ??= new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), ApiDbContext);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed)
            {
                return;
            }

            if (disposing)
            {
                // free managed resources
                ApiDbContext.Dispose();
            }

            isDisposed = true;
        }
    }
}
