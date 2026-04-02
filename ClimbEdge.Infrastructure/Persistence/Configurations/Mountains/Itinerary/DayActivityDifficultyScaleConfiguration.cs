using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Mountains.Itinerary
{
    internal class DayActivityDifficultyScaleConfiguration : IEntityTypeConfiguration<DayActivityDifficultyScale>
    {
        public void Configure(EntityTypeBuilder<DayActivityDifficultyScale> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.DayActivity).WithMany(e => e.DifficultyScales).HasForeignKey(e => e.DayActivityId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
