using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfig
{
    public class MenuItemConfig : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> entity)
        {
            entity.HasKey(e => new { e.MenuItemID });

            entity.Property(e => e.Name).IsRequired();
            //entity.Property (e => e.Image).IsRequired ();
            entity.Property(e => e.Description).IsRequired();

            entity.HasOne(d => d.SubCategory)
                .WithMany(p => p.MenuItems)
                .HasForeignKey(d => d.SubCategoryID);
        }
    }
}
