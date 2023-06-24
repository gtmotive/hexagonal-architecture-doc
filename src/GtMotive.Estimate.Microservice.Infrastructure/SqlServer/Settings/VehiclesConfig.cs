using GtMotive.Estimate.Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GtMotive.Estimate.Microservice.Infrastructure.SqlServer.Settings
{
    internal class VehiclesConfig : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            if (builder != null)
            {
                builder.ToTable("Vehicles");
                builder.HasKey(k => k.VehicleId);
                builder.Property(p => p.VehicleId)
                   .ValueGeneratedOnAdd();

                builder
                    .HasMany(p => p.Rentals)
                    .WithOne(r => r.Vehicle);
            }
        }
    }
}
