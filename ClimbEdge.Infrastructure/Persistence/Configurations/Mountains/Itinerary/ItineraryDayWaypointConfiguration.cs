using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Mountains.Itinerary
{
    internal class ItineraryDayWaypointConfiguration : IEntityTypeConfiguration<ItineraryDayWaypoint>
    {
        public void Configure(EntityTypeBuilder<ItineraryDayWaypoint> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Location).HasGeoZ();
            builder.HasOne(e => e.ItineraryDayTrack).WithMany(e => e.Waypoints).HasForeignKey(e => e.ItineraryDayTrackId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
