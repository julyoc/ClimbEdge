using ClimbEdge.Domain.Entities.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Versioning
{
    internal class VersionDependencyConfiguration : IEntityTypeConfiguration<VersionDependency>
    {
        public void Configure(EntityTypeBuilder<VersionDependency> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.DependencyEntityType).IsRequired();
            builder.HasOne(e => e.ConfigurationVersion).WithMany(e => e.Dependencies).HasForeignKey(e => e.ConfigurationVersionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
