using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Mountains.Itinerary
{
    internal class ItineraryDayWaypointFileConfiguration : IEntityTypeConfiguration<ItineraryDayWaypointFile>
    {
        public void Configure(EntityTypeBuilder<ItineraryDayWaypointFile> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.FileName).IsRequired();
            builder.Property(e => e.FileUrl).IsRequired();
            builder.HasOne(e => e.ItineraryDayWaypoint).WithMany().HasForeignKey(e => e.ItineraryDayWaypointId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
