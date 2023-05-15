using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Polly;

namespace GtMotive.Estimate.Microservice.Infrastructure
{
    /// <summary>
    /// Base Class for repository creation.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {
        private readonly DbContext _dbContext;

        protected RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public virtual void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        /// <inheritdoc/>
        public virtual void AddRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
        }

        /// <inheritdoc/>
        public virtual void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        /// <inheritdoc/>
        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
        }

        /// <inheritdoc/>
        public virtual void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        /// <inheritdoc/>
        public virtual async Task<T> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default)
            where TId : notnull
        {
            return await _dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task<IEnumerable<T>> ToListAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().AnyAsync(predicate, cancellationToken);
        }
    }
}
