using ClimbEdge.Domain.Entities.Climbing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Climbing
{
    internal class RockFeaturesConfiguration : IEntityTypeConfiguration<RockFeatures>
    {
        public void Configure(EntityTypeBuilder<RockFeatures> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.ClimbRoute).WithMany().HasForeignKey(e => e.ClimbRouteId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
