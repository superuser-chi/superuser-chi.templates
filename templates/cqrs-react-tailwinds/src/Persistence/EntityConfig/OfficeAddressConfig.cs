using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfig
{
    public class OfficeAddressConfig : IEntityTypeConfiguration<OfficeAddress>
    {
        public void Configure(EntityTypeBuilder<OfficeAddress> entity)
        {
            entity.HasKey(e => new { e.OfficeAddressID });

            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.LocationID).IsRequired();

            entity.HasOne(d => d.Location)
                .WithMany(p => p.Offices)
                .HasForeignKey(d => d.LocationID);

        }
    }
}
