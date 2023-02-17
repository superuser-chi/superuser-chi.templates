using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfig
{
    public class PaymentTypeConfig : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> entity)
        {
            entity.HasKey(e => new { e.PaymentTypeID });
            entity.Property(e => e.Name).IsRequired();
        }
    }
}
