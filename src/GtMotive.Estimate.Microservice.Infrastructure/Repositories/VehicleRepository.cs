using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Contracts.Repositories;
using GtMotive.Estimate.Microservice.ApplicationCore.Enums;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    /// <summary>
    /// VehicleRepository.
    /// </summary>
    public class VehicleRepository : RepositoryBase<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(ApiDbContext context)
            : base(context)
        {
        }

        public async Task<Vehicle> GetVehicleInfoByIdAsync(int id)
        {
            return await GetWhere(x => x.Id == id).Include(c => c.VehicleState).FirstOrDefaultAsync();
        }

        public async Task<List<Vehicle>> GetVehiclesInfoAsync()
        {
            return await GetWhere(x => DateTime.Now.Year - x.ManufacturingDate.Year <= 5 && x.VehicleStateId == (int)VehicleStateValues.Available)
                .Include(c => c.VehicleState)
                .ToListAsync();
        }
    }
}
