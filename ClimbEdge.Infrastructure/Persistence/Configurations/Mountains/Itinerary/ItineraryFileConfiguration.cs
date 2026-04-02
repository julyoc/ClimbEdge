using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Mountains.Itinerary
{
    internal class ItineraryFileConfiguration : IEntityTypeConfiguration<ItineraryFile>
    {
        public void Configure(EntityTypeBuilder<ItineraryFile> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.FileName).IsRequired();
            builder.Property(e => e.FileUrl).IsRequired();
            builder.HasOne(e => e.Expedition).WithMany().HasForeignKey(e => e.ExpeditionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
