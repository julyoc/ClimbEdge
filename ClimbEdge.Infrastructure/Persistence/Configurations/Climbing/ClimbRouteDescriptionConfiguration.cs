using ClimbEdge.Domain.Entities.Climbing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Climbing
{
    internal class ClimbRouteDescriptionConfiguration : IEntityTypeConfiguration<ClimbRouteDescription>
    {
        public void Configure(EntityTypeBuilder<ClimbRouteDescription> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.ClimbRoute).WithMany(e => e.Descriptions).HasForeignKey(e => e.ClimbRouteId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
