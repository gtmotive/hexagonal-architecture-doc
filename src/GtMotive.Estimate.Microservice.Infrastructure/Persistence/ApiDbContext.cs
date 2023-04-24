using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Enums;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Persistence
{
    /// <summary>
    /// ApiDbContext.
    /// </summary>
    public class ApiDbContext : IdentityDbContext<User, Role, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiDbContext"/> class.
        /// ApiDbContext.
        /// </summary>
        /// <param name="options">DbContextOptions.</param>
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets Vehicles entities.
        /// </summary>
        public DbSet<Vehicle> Vehicles { get; set; }

        /// <summary>
        /// Gets or sets VehicleStates entities.
        /// </summary>
        public DbSet<VehicleState> VehicleStates { get; set; }

        /// <summary>
        /// Gets or sets Reservations entities.
        /// </summary>
        public DbSet<Reservation> Reservations { get; set; }

        /// <summary>
        /// SaveChangesAsync.
        /// </summary>
        /// <param name="cancellationToken">CancellationToken.</param>
        /// <returns>int.</returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// OnModelCreating.
        /// </summary>
        /// <param name="builder">ModelBuilder.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            if (builder != null)
            {
                CreateConstraints(builder);
                SeedInitialData(builder);
            }
        }

        /// <summary>
        /// CreateConstraints
        /// Configure entities constraints.
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder.</param>
        private static void CreateConstraints(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasOne(e => e.VehicleState)
                .WithMany(e => e.Vehicles)
                .HasForeignKey(e => e.VehicleStateId);

            modelBuilder.Entity<Reservation>()
                .HasOne(e => e.Vehicle)
                .WithMany(e => e.Reservations)
                .HasForeignKey(e => e.VehicleId);

            modelBuilder.Entity<Reservation>()
                .HasOne(e => e.User)
                .WithMany(e => e.Reservations)
                .HasForeignKey(e => e.UserId);
        }

        /// <summary>
        /// SeedInitialData.
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder.</param>
        private static void SeedInitialData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleState>().HasData(
               new VehicleState { Id = 1, Name = "Available" },
               new VehicleState { Id = 2, Name = "Rented" },
               new VehicleState { Id = 3, Name = "Maintenance" });

            modelBuilder.Entity<Vehicle>().HasData(
               new Vehicle { Id = 1, RegistrationNumber = "6296HKZ", ManufacturingDate = DateTime.Now.AddYears(-2), VehicleStateId = (int)VehicleStateValues.Available },
               new Vehicle { Id = 2, RegistrationNumber = "6734IOP", ManufacturingDate = DateTime.Now.AddYears(-3), VehicleStateId = (int)VehicleStateValues.Available },
               new Vehicle { Id = 3, RegistrationNumber = "7688CFR", ManufacturingDate = DateTime.Now.AddYears(-6), VehicleStateId = (int)VehicleStateValues.Available },
               new Vehicle { Id = 4, RegistrationNumber = "3462CVB", ManufacturingDate = DateTime.Now.AddYears(-2), VehicleStateId = (int)VehicleStateValues.Maintenance },
               new Vehicle { Id = 5, RegistrationNumber = "4512ERX", ManufacturingDate = DateTime.Now.AddYears(-1), VehicleStateId = (int)VehicleStateValues.Rented });
        }
    }
}
