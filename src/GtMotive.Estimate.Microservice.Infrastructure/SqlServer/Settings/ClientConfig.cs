using GtMotive.Estimate.Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GtMotive.Estimate.Microservice.Infrastructure.SqlServer.Settings
{
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            if (builder != null)
            {
                builder.ToTable("Clients");
                builder.HasKey(k => k.ClientId);
                builder.Property(p => p.ClientId)
                   .ValueGeneratedOnAdd();

                builder
                    .HasMany(c => c.Rentals)
                    .WithOne(r => r.Client);
            }
        }
    }
}
