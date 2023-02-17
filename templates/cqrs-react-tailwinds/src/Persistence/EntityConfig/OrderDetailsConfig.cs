using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfig
{
    public class OrderDetailsConfig : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> entity)
        {
            entity.HasKey(e => e.OrderDetailsID);
            entity.Property(e => e.OrderDetailsID)
                         .IsRequired()
                         .ValueGeneratedOnAdd()
                         .UseIdentityColumn();

            entity.Property(e => e.Quantity).IsRequired();

            entity.HasOne(d => d.MenuItem)
                .WithOne(p => p.OrdeDetail)
                .HasForeignKey<OrderDetails>(d => d.MenuItemID);

            entity.HasOne(d => d.Order)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderID);
        }
    }
}
