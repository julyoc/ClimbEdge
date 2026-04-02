using ClimbEdge.Domain.Entities.Help;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Help
{
    internal class EscalationRuleConfiguration : IEntityTypeConfiguration<EscalationRule>
    {
        public void Configure(EntityTypeBuilder<EscalationRule> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.Name).IsRequired();
        }
    }
}
