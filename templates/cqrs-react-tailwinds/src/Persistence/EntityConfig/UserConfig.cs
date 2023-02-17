using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.EntityConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.Property(e => e.IsNewUser).HasDefaultValue(true);

            entity.Property(e => e.LocationID)
                  .HasMaxLength(450);

            entity.HasOne(d => d.Department)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.DepartmentID);

            entity.HasOne(i => i.Location)
                  .WithMany(i => i.Users)
                  .HasForeignKey(i => i.LocationID);

        }
    }
}
