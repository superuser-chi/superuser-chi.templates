using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfig
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> entity)
        {
            entity.HasKey(e => new { e.AccountID });
            entity.Property(e => e.AccountName).IsRequired();
            entity.Property(e => e.AccountBalance).HasColumnType("decimal(14, 2)").IsRequired();
            entity.HasDiscriminator<string>("AccountType")
                .HasValue<DepartmentalAccount>(AccountTypes.DepartmentalAccount.ToString())
                .HasValue<IndividualAccount>(AccountTypes.IndividualAccount.ToString());
        }
    }
}
