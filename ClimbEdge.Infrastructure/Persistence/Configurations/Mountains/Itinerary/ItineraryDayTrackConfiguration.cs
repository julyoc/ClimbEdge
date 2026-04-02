using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Mountains.Itinerary
{
    internal class ItineraryDayTrackConfiguration : IEntityTypeConfiguration<ItineraryDayTrack>
    {
        public void Configure(EntityTypeBuilder<ItineraryDayTrack> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.TrackData).HasGeoZ();
            builder.Property(e => e.PlannedRoute).HasGeoZ();
            builder.HasOne(e => e.ItineraryTrack).WithMany(e => e.DayTracks).HasForeignKey(e => e.ItineraryTrackId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
