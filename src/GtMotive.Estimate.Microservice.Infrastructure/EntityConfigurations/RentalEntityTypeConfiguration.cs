using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet;
using GtMotive.Estimate.Microservice.Domain.Aggregates.Rental;
using GtMotive.Estimate.Microservice.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GtMotive.Estimate.Microservice.Infrastructure.EntityConfigurations
{
    internal class RentalEntityTypeConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> configuration)
        {
            configuration.ToTable(nameof(GtMotiveFleetContext.Rentals), GtMotiveFleetContext.DEFAULTSCHEMA);

            configuration.HasKey(p => p.Id);
            configuration.Property(p => p.Id).UseIdentityColumn();

            configuration.Property(p => p.VehicleId).IsRequired();
            configuration.Property(p => p.CustomerId).IsRequired();
            configuration.Property(p => p.Date).IsRequired();

            configuration.HasOne<Vehicle>()
                .WithMany()
                .HasForeignKey(p => p.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
