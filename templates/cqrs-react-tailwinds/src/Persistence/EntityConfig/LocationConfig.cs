using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfig
{
    public class LocationConfig : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> entity)
        {
            entity.HasKey(e => new { e.LocationID });
            entity.Property(e => e.Name).IsRequired();
        }
    }
}
