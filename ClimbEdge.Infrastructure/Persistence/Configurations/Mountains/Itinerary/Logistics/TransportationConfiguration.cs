using ClimbEdge.Domain.Entities.Mountains.Itinerary.Logistics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Mountains.Itinerary.Logistics
{
    internal class TransportationConfiguration : IEntityTypeConfiguration<Transportation>
    {
        public void Configure(EntityTypeBuilder<Transportation> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.Type).IsRequired();
            builder.Property(e => e.Departure).HasGeoZ();
            builder.Property(e => e.Arrival).HasGeoZ();
            builder.HasOne(e => e.Expedition).WithMany().HasForeignKey(e => e.ExpeditionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
