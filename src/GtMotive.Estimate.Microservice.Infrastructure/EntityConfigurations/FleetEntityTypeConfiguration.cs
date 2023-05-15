using GtMotive.Estimate.Microservice.Domain.Aggregates.Fleet;
using GtMotive.Estimate.Microservice.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GtMotive.Estimate.Microservice.Infrastructure.EntityConfigurations
{
    internal class FleetEntityTypeConfiguration : IEntityTypeConfiguration<Fleet>
    {
        public void Configure(EntityTypeBuilder<Fleet> configuration)
        {
            configuration.ToTable(nameof(GtMotiveFleetContext.Fleets) , GtMotiveFleetContext.DEFAULTSCHEMA);

            configuration.HasKey(p => p.Id);
            configuration.Property(p => p.Id).UseIdentityColumn();

            configuration.OwnsOne(
                p => p.Name,
                builder =>
                {
                    builder.Property(name => name.Text).HasMaxLength(255).IsRequired();
                });

            var navigation = configuration.Metadata.FindNavigation(nameof(Fleet.Vehicles));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
