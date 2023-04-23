using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Contracts.Repositories;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    /// <summary>
    /// ReservationRepository.
    /// </summary>
    public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
    {
        public ReservationRepository(ApiDbContext context)
            : base(context)
        {
        }

        public async Task<List<Reservation>> GetReservationsByUserIdAsync(Guid id)
        {
            return await GetWhere(x => x.UserId == id).Include(c => c.Vehicle).Include(c => c.User).ToListAsync();
        }

        public async Task<List<Reservation>> GetAllReservationsInfoAsync()
        {
            return await GetWhere().Include(c => c.Vehicle).Include(c => c.User).ToListAsync();
        }
    }
}
