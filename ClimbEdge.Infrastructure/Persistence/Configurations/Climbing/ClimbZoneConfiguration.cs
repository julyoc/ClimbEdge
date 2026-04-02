using ClimbEdge.Domain.Entities.Climbing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Climbing
{
    internal class ClimbZoneConfiguration : IEntityTypeConfiguration<ClimbZone>
    {
        public void Configure(EntityTypeBuilder<ClimbZone> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Location).HasGeoZ();
        }
    }
}
