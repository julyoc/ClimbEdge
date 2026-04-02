using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Mountains.Itinerary
{
    internal class ItineraryTrackConfiguration : IEntityTypeConfiguration<ItineraryTrack>
    {
        public void Configure(EntityTypeBuilder<ItineraryTrack> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.PlannedRoute).HasGeoZ();
            builder.Property(e => e.ActualRoute).HasGeoZ();
            builder.HasOne(e => e.Expedition).WithMany().HasForeignKey(e => e.ExpeditionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
