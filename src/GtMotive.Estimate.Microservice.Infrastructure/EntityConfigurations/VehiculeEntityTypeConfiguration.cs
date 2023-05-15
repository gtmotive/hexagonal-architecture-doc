using GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet;
using GtMotive.Estimate.Microservice.Domain.Aggregates.Rental;
using GtMotive.Estimate.Microservice.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GtMotive.Estimate.Microservice.Infrastructure.EntityConfigurations
{
    internal class VehiculeEntityTypeConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> configuration)
        {
            configuration.ToTable(nameof(GtMotiveFleetContext.Vehicles) , GtMotiveFleetContext.DEFAULTSCHEMA);

            configuration.HasKey(p => p.Id);
            configuration.Property(p => p.Id).UseIdentityColumn();
            configuration.Property(p => p.FleetId).IsRequired();           
            configuration.Property(p => p.ModelYear).IsRequired();
            configuration.Property(p => p.IsAvailable).IsRequired();
          
            configuration.OwnsOne(
                p => p.Name,
                builder =>
                {
                    builder.Property(name => name.Text).HasMaxLength(255).IsRequired();
                });
        }
    }
}
