using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Mountains.Itinerary
{
    internal class ItineraryDayTrackFileConfiguration : IEntityTypeConfiguration<ItineraryDayTrackFile>
    {
        public void Configure(EntityTypeBuilder<ItineraryDayTrackFile> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.FileName).IsRequired();
            builder.Property(e => e.FileUrl).IsRequired();
            builder.HasOne(e => e.ItineraryDayTrack).WithMany().HasForeignKey(e => e.ItineraryDayTrackId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
