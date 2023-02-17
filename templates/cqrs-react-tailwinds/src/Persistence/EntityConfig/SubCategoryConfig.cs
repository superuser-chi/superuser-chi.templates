using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfig
{
    public class SubCategoryConfig : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> entity)
        {
            entity.HasKey(e => new { e.SubCategoryID });

            entity.Property(e => e.SubCategoryName).IsRequired();

            entity.HasOne(d => d.Category)
                .WithMany(p => p.SubCategories)
                .HasForeignKey(d => d.CategoryID);
        }
    }
}
