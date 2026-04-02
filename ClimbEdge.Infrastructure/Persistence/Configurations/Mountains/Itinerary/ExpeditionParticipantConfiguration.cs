using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Mountains.Itinerary
{
    internal class ExpeditionParticipantConfiguration : IEntityTypeConfiguration<ExpeditionParticipant>
    {
        public void Configure(EntityTypeBuilder<ExpeditionParticipant> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasIndex(e => new { e.ExpeditionId, e.UserId }).IsUnique();
            builder.HasOne(e => e.Expedition).WithMany(e => e.ExpeditionParticipants).HasForeignKey(e => e.ExpeditionId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.User).WithMany(e => e.ExpeditionParticipants).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
