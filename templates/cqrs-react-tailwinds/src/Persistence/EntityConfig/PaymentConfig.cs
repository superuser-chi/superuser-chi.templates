using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfig
{
    public class PaymentConfig : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> entity)
        {
            entity.HasKey(e => new { e.PaymentID });
            entity.Property(e => e.Amount)
                    .HasColumnType("decimal(14, 2)")
                    .IsRequired();
            entity.Property(e => e.Reference)
                    .HasDefaultValue("No reference")
                    .IsRequired();
            entity.Property(e => e.Date).IsRequired();

            entity.HasOne(d => d.Account)
                .WithMany(p => p.Payments)
                .HasForeignKey(d => d.AccountID);

            entity.HasOne(d => d.PaymentType)
                .WithMany(p => p.Payments)
                .HasForeignKey(d => d.PaymentTypeID);
        }
    }
}
