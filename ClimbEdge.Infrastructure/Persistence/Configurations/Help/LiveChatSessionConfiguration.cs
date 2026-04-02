using ClimbEdge.Domain.Entities.Help;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Help
{
    internal class LiveChatSessionConfiguration : IEntityTypeConfiguration<LiveChatSession>
    {
        public void Configure(EntityTypeBuilder<LiveChatSession> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.SessionId).IsRequired();
            builder.HasIndex(e => e.SessionId).IsUnique();
        }
    }
}
