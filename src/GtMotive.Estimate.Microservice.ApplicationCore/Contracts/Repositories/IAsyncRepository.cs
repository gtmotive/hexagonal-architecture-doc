using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Common;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Contracts.Repositories
{
    /// <summary>
    /// Interface IAsyncRepository (Base Repository)
    /// Added Unit of work methods pattern (Entities).
    /// </summary>
    /// <typeparam name="T">T.</typeparam>
    public interface IAsyncRepository<T>
        where T : BaseDomainModel
    {
        /// <summary>
        /// GetAllAsync.
        /// </summary>
        /// <returns>IReadOnlyListT.</returns>
        Task<IReadOnlyList<T>> GetAllAsync();

        /// <summary>
        /// GetAsync.
        /// </summary>
        /// <param name="predicate">Predicate.</param>
        /// <returns>IReadOnlyList T.</returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// GetAsync.
        /// </summary>
        /// <param name="predicate">predicate.</param>
        /// <param name="orderBy">order.</param>
        /// <param name="includeString">include.</param>
        /// <param name="disableTracking">disable.</param>
        /// <returns>IReadOnlyList T.</returns>
        Task<IReadOnlyList<T>> GetAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeString = null,
            bool disableTracking = true);

        /// <summary>
        /// GetByIdAsync.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>T.</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// AddAsync.
        /// </summary>
        /// <param name="entity">T entity.</param>
        /// <returns>T.</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// UpdateAsync.
        /// </summary>
        /// <param name="entity">T Entity.</param>
        /// <returns>T.</returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// DeleteAsync.
        /// </summary>
        /// <param name="entity">T Entity.</param>
        /// <returns>T.</returns>
        Task DeleteAsync(T entity);

        /// <summary>
        /// Get with where expression.
        /// </summary>
        /// <param name="where">Expression.</param>
        /// <returns>T.</returns>
        IQueryable<T> GetWhere(Expression<Func<T, bool>> where = null);
    }
}
