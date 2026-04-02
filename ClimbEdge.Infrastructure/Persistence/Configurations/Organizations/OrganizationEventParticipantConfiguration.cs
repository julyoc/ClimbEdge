using ClimbEdge.Domain.Entities.Organizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Organizations
{
    internal class OrganizationEventParticipantConfiguration : IEntityTypeConfiguration<OrganizationEventParticipant>
    {
        public void Configure(EntityTypeBuilder<OrganizationEventParticipant> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasIndex(e => new { e.EventId, e.UserId }).IsUnique();
            builder.HasOne(e => e.Event).WithMany(e => e.Participants).HasForeignKey(e => e.EventId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
