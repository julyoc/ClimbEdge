using ClimbEdge.Domain.Entities.Help;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Help
{
    internal class UserHelpActivityConfiguration : IEntityTypeConfiguration<UserHelpActivity>
    {
        public void Configure(EntityTypeBuilder<UserHelpActivity> builder)
        {
            builder.ConfigureBaseModel();
        }
    }
}
