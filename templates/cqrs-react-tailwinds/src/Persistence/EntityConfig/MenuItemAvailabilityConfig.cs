using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfig
{
    public class MenuItemAvailabilityConfig : IEntityTypeConfiguration<MenuItemAvailability>
    {
        public void Configure(EntityTypeBuilder<MenuItemAvailability> entity)
        {
            entity.HasKey(e => new { e.MenuItemAvailabilityID });

            entity.Property(e => e.AvailableDate).IsRequired();
            entity.Property(e => e.Quantity).IsRequired();

            entity.HasOne(d => d.MenuItem)
                .WithMany(p => p.MenuItemAvailabilities)
                .HasForeignKey(d => d.MenuItemID);

            entity.HasOne(d => d.Location)
                .WithMany(d => d.Availabilities)
                .HasForeignKey(d => d.LocationID);
        }
    }
}
