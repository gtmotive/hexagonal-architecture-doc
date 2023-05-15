using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Interface base for respository.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    public interface IRepositoryBase<T>
        where T : class
    {
        /// <summary>
        /// Add entity to repository.
        /// </summary>
        /// <param name="entity">Entity.</param>
        void Add(T entity);

        /// <summary>
        /// Add entities to repository.
        /// </summary>
        /// <param name="entities">Entities.</param>
        void AddRange(IEnumerable<T> entities);

        /// <summary>
        /// Gets the entity by primary identifier.
        /// </summary>
        /// <typeparam name="TId">Type of identifier.</typeparam>
        /// <param name="id">Id.</param>
        /// <param name="cancellationToken">CancellationToken.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<T> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default)
            where TId : notnull;

        /// <summary>
        /// Gets a resultset of entities.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<T>> ToListAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Update entity to repository.
        /// </summary>
        /// <param name="entity">Entity.</param>
        void Update(T entity);

        /// <summary>
        /// Update entity to repository.
        /// </summary>
        /// <param name="entities">Entities.</param>
        void UpdateRange(IEnumerable<T> entities);

        /// <summary>
        /// Remove entity to repository.
        /// </summary>
        /// <param name="entity">Entity.</param>
        void Remove(T entity);
    }
}
