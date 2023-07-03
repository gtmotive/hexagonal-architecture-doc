using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.SqlServer.Settings;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.SqlServer.Context
{
    public class RentingContext : DbContext
    {
        public RentingContext(DbContextOptions<RentingContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder != null)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.ApplyConfiguration(new ClientConfig());
                modelBuilder.ApplyConfiguration(new VehiclesConfig());
                modelBuilder.ApplyConfiguration(new RentalConfig());
            }
        }
    }
}
