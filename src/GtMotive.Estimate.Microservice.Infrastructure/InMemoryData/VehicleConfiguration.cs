using GtMotive.Estimate.Microservice.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GtMotive.Estimate.Microservice.Infrastructure.InMemoryData
{
    internal class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(v => v.VehicleId);
            builder.OwnsOne(v => v.LicensePlate);
            builder.OwnsOne(v => v.Make);
            builder.OwnsOne(v => v.Model);
            builder.OwnsOne(v => v.ManufactureYear);
        }
    }
}
