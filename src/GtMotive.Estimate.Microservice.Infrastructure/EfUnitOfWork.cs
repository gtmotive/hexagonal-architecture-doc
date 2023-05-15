using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Contexts;

namespace GtMotive.Estimate.Microservice.Infrastructure
{
    public sealed class EfUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly GtMotiveFleetContext _context;
        private bool _disposed;

        public EfUnitOfWork(GtMotiveFleetContext context)
        {
            _context = context;
        }

        public async Task<int> SaveAsync()
        {
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }
    }
}
