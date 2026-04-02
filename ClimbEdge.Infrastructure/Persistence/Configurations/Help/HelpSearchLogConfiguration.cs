using ClimbEdge.Domain.Entities.Help;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Help
{
    internal class HelpSearchLogConfiguration : IEntityTypeConfiguration<HelpSearchLog>
    {
        public void Configure(EntityTypeBuilder<HelpSearchLog> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.SearchQuery).IsRequired();
        }
    }
}
