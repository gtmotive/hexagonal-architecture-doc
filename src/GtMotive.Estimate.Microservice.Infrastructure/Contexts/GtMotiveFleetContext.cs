using System;
using System.IO;
using GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet;
using GtMotive.Estimate.Microservice.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GtMotive.Estimate.Microservice.Infrastructure.Contexts
{
    public class GtMotiveFleetContext : DbContext
    {
        public const string DEFAULTSCHEMA = "Rental";

        /// <summary>
        /// Initializes a new instance of the <see cref="GtMotiveFleetContext"/> class.
        /// </summary>
        public GtMotiveFleetContext()
            : base()
        {
        }

        public GtMotiveFleetContext(DbContextOptions<GtMotiveFleetContext> options)
            : base(options)
        {
        }

        public DbSet<Fleet> Fleets { get; set; }
    
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Vehicle> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfiguration(new FleetEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VehiculeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RentalEntityTypeConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder?.IsConfigured == false)
            {
                var configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

                var connectionString = configuration.GetSection("SqlServer:ConnectionString").Value;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
