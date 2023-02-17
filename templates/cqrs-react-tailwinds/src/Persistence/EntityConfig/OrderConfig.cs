using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfig
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.HasKey(e => e.OrderID);
            entity.Property(e => e.OrderID)
                                    .IsRequired()
                                    .ValueGeneratedOnAdd()
                                    .UseIdentityColumn();
            entity.HasIndex(p => new { p.OrderRef, p.OrderDate }).IsUnique();
            
            entity.Property(e => e.OrderDate).HasColumnType("date").IsRequired();
            entity.Property(e => e.OrderTotal).HasColumnType("decimal(14, 2)").IsRequired();
            entity.Property(e => e.PickUpTime).IsRequired();
            entity.Property(e => e.PickupName).IsRequired();
            entity.Property(e => e.Status).IsRequired();
            entity.Property(e => e.IsTenant)
                    .IsRequired();
            entity.Property(e => e.PaymentStatus).HasConversion<string>().IsRequired();
            entity.Property(e => e.Comment).IsRequired();
            entity.Property(e => e.PickupName).IsRequired();

            entity.HasDiscriminator<string>("OrderType")
             .HasValue<Order>(OrderType.CashOrder.ToString())
             .HasValue<OnlineOrder>(OrderType.OnlineOrder.ToString());

            entity.HasMany(d => d.OrderDetails)
                .WithOne(p => p.Order)
                .HasForeignKey(d => d.OrderID);

            entity.HasOne(d => d.Location)
                .WithMany(d => d.Orders)
                .HasForeignKey(d => d.LocationID);
        }
    }
}
