using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Mountains.Itinerary
{
    internal class ItineraryTrackFileConfiguration : IEntityTypeConfiguration<ItineraryTrackFile>
    {
        public void Configure(EntityTypeBuilder<ItineraryTrackFile> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.FileName).IsRequired();
            builder.Property(e => e.FileUrl).IsRequired();
            builder.HasOne(e => e.ItineraryTrack).WithMany().HasForeignKey(e => e.ItineraryTrackId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
