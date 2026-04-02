using ClimbEdge.Domain.Entities.Climbing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Climbing
{
    internal class ClimbRouteConfiguration : IEntityTypeConfiguration<ClimbRoute>
    {
        public void Configure(EntityTypeBuilder<ClimbRoute> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.Name).IsRequired();
            builder.HasOne(e => e.ClimbZone).WithMany(e => e.ClimbRoutes).HasForeignKey(e => e.ClimbZoneId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
