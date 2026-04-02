using ClimbEdge.Domain.Entities.Help;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Help
{
    internal class SupportMetricsConfiguration : IEntityTypeConfiguration<SupportMetrics>
    {
        public void Configure(EntityTypeBuilder<SupportMetrics> builder)
        {
            builder.ConfigureBaseModel();
        }
    }
}
