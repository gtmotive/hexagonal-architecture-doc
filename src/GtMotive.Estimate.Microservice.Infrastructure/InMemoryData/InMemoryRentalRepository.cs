using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Repositories;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.InMemoryVehicle;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.InMemoryData
{
    public class InMemoryRentalRepository : IRentalRepository
    {
        private readonly AppDbContext _context;

        public InMemoryRentalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Rental> GetByIdAsync(Guid id)
        {
            return await _context.Rentals.FindAsync(id);
        }

        public async Task<IEnumerable<Rental>> GetAllAsync()
        {
            return await _context.Rentals.ToListAsync();
        }

        public async Task<IEnumerable<Rental>> GetByCustomerIdAsync(Guid customerId)
        {
            return await _context.Rentals
                                 .Where(r => r.CustomerId == customerId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Rental>> GetActiveRentalsByCustomerId(Guid customerId)
        {
            return await _context.Rentals
                                 .Where(r => r.CustomerId == customerId && r.IsActive)
                                 .ToListAsync();
        }

        public async Task AddAsync(Rental rental)
        {
            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Rental rental)
        {
            _context.Entry(rental).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental != null)
            {
                _context.Rentals.Remove(rental);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Rental>> GetActiveRentals()
        {
            return await _context.Rentals
                                 .Where(r => r.IsActive)
                                 .ToListAsync();
        }
    }
}
