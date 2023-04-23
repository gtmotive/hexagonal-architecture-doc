using GtMotive.Estimate.Microservice.ApplicationCore.Contracts.Repositories;
using GtMotive.Estimate.Microservice.Domain.Common;
using GtMotive.Estimate.Microservice.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    /// <summary>
    /// RepositoryBase.
    /// </summary>
    /// <typeparam name="T">RepositoryBase T.</typeparam>
    public class RepositoryBase<T> : IAsyncRepository<T>
        where T : BaseDomainModel
    {
        /// <summary>
        /// Context.
        /// </summary>
        private readonly ApiDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class.
        /// RepositoryBase.
        /// </summary>
        /// <param name="context">ApiDbContext.</param>
        public RepositoryBase(ApiDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// AddAsync.
        /// </summary>
        /// <param name="entity">New T.</param>
        /// <returns>T.</returns>
        public async Task<T> AddAsync(T entity)
        {
            var newEntity = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return newEntity.Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (!string.IsNullOrWhiteSpace(includeString))
            {
                query = query.Include(includeString);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return orderBy != null ? await orderBy(query).ToListAsync() : (IReadOnlyList<T>)await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> where = null)
        {
            return where != null ? _context.Set<T>().Where(where) : _context.Set<T>();
        }
    }
}
