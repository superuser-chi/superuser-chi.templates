using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfig
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> entity)
        {
            entity.HasKey(e => new { e.DepartmentID });

            entity.Property(e => e.Code).IsRequired();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Description);

            entity.HasOne(d => d.Account)
                .WithOne(p => p.Department)
                .HasForeignKey<Department>(d => d.AccountID);
        }
    }
}
