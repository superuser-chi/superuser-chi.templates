using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfig
{
    public class MeetingParticipantConfig : IEntityTypeConfiguration<MeetingParticipant>
    {
        public void Configure(EntityTypeBuilder<MeetingParticipant> entity)
        {
            entity.HasKey(e => new { e.MeetingParticipantID });

            entity.Property(e => e.UserID).IsRequired();
            entity.Property(e => e.MeetingID).IsRequired();
        }
    }
}
