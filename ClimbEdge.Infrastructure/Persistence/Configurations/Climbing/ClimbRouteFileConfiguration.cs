using ClimbEdge.Domain.Entities.Climbing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Climbing
{
    internal class ClimbRouteFileConfiguration : IEntityTypeConfiguration<ClimbRouteFile>
    {
        public void Configure(EntityTypeBuilder<ClimbRouteFile> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.FileName).IsRequired();
            builder.Property(e => e.FileUrl).IsRequired();
            builder.HasOne(e => e.ClimbRoute).WithMany(e => e.Files).HasForeignKey(e => e.ClimbRouteId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
