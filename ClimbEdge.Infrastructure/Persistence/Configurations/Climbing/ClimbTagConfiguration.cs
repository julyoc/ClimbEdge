using ClimbEdge.Domain.Entities.Climbing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Climbing
{
    internal class ClimbTagConfiguration : IEntityTypeConfiguration<ClimbTag>
    {
        public void Configure(EntityTypeBuilder<ClimbTag> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.Name).IsRequired();
            builder.HasIndex(e => e.Name).IsUnique();
        }
    }
}
