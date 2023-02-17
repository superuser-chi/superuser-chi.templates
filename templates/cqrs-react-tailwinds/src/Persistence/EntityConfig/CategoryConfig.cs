using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfig
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasKey(e => new { e.CategoryID });

            entity.HasIndex(e => e.CategoryID);

            entity.Property(e => e.CategoryID).IsRequired();
        }
    }
}
