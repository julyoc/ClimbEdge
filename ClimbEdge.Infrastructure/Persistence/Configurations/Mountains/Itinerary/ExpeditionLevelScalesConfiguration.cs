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
    internal class ExpeditionLevelScalesConfiguration : IEntityTypeConfiguration<ExpeditionLevelScales>
    {
        public void Configure(EntityTypeBuilder<ExpeditionLevelScales> builder)
        {
            builder.ConfigureBaseModel();

            builder.HasIndex(e => new { e.ExpeditionId, e.DifficultyScaleId }).IsUnique();

            builder.HasOne(e => e.Expedition).WithMany(e => e.ExpeditionLevelScales).HasForeignKey(e => e.ExpeditionId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.DifficultyScale).WithMany(e => e.ExpeditionLevelScales).HasForeignKey(e => e.DifficultyScaleId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
