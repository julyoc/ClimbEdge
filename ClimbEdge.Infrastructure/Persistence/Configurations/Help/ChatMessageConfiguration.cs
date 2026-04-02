using ClimbEdge.Domain.Entities.Help;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Help
{
    internal class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.Session).WithMany(e => e.Messages).HasForeignKey(e => e.SessionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
