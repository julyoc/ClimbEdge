using ClimbEdge.Domain.Entities.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Versioning
{
    internal class ConfigurationVersionConfiguration : IEntityTypeConfiguration<ConfigurationVersion>
    {
        public void Configure(EntityTypeBuilder<ConfigurationVersion> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.EntityType).IsRequired();
            builder.Property(e => e.Content).IsRequired();
            builder.HasIndex(e => new { e.EntityType, e.EntityId, e.VersionNumber }).IsUnique();
        }
    }
}
