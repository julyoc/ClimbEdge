using ClimbEdge.Domain.Entities.Help;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Help
{
    internal class HelpFeedbackConfiguration : IEntityTypeConfiguration<HelpFeedback>
    {
        public void Configure(EntityTypeBuilder<HelpFeedback> builder)
        {
            builder.ConfigureBaseModel();
        }
    }
}
