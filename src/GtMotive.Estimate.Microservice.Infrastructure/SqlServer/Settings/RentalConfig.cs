using GtMotive.Estimate.Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GtMotive.Estimate.Microservice.Infrastructure.SqlServer.Settings
{
    public class RentalConfig : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            if (builder != null)
            {
                builder.ToTable("Retals");
                builder.HasKey(k => new { k.VehicleId, k.ClientId });

                builder
                    .HasOne(r => r.Vehicle)
                    .WithMany(p => p.Rentals);

                builder
                    .HasOne(r => r.Client)
                    .WithMany(c => c.Rentals);
            }
        }
    }
}
