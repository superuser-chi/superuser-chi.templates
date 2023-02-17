using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfig
{
    public class MenuItemPriceConfig : IEntityTypeConfiguration<MenuItemPrice>
    {
        public void Configure(EntityTypeBuilder<MenuItemPrice> entity)
        {
            entity.HasKey(e => new { e.MenuItemPriceID });
            entity.Property(b => b.Price).HasColumnType("decimal(5, 2)");
            entity.Property(b => b.IsExternal)
                        .IsRequired()
                        .HasDefaultValue(false);

            entity.HasOne(d => d.MenuItem)
                .WithMany(p => p.MenuItemPrices)
                .HasForeignKey(d => d.MenuItemID);
        }
    }
}

