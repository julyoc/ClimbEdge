using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Mountains.Itinerary
{
    internal class DayActivityConfiguration : IEntityTypeConfiguration<DayActivity>
    {
        public void Configure(EntityTypeBuilder<DayActivity> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.ActivityName).IsRequired();
            builder.Property(e => e.Location).HasGeoZ();
            builder.HasOne(e => e.ItineraryDay).WithMany().HasForeignKey(e => e.ItineraryDayId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
