using ClimbEdge.Domain.Entities.Climbing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Climbing
{
    internal class ClimbZoneFileConfiguration : IEntityTypeConfiguration<ClimbZoneFile>
    {
        public void Configure(EntityTypeBuilder<ClimbZoneFile> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.FileName).IsRequired();
            builder.Property(e => e.FileUrl).IsRequired();
            builder.HasOne(e => e.ClimbZone).WithMany(e => e.Files).HasForeignKey(e => e.ClimbZoneId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
