using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfig
{
    public class MeetingConfig : IEntityTypeConfiguration<Meeting>
    {
        public void Configure(EntityTypeBuilder<Meeting> entity)
        {
            entity.HasKey(e => new { e.MeetingID });
            entity.Property(e => e.MeetingID)
                .IsRequired()
                .ValueGeneratedOnAdd();
            entity.Property(e => e.Comments);
            entity.Property(e => e.StartDate).IsRequired();
            entity.Property(e => e.EndDate).IsRequired();
            entity.Property(e => e.StartDate).IsRequired();
            entity.Property(e => e.NumberOfParticipants).IsRequired();
            entity.Property(e => e.Lunch).IsRequired();
            entity.Property(e => e.Breakfast).IsRequired();
            entity.Property(e => e.MeetingType).HasConversion<string>();

            entity.HasOne(d => d.Location)
                .WithMany(d => d.Meetings)
                .HasForeignKey(d => d.LocationID);
        }
    }
}
