using ClimbEdge.Domain.Entities.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Comments
{
    internal class CommentMentionConfiguration : IEntityTypeConfiguration<CommentMention>
    {
        public void Configure(EntityTypeBuilder<CommentMention> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasIndex(e => new { e.CommentId, e.MentionedUserId }).IsUnique();
            builder.HasOne(e => e.Comment).WithMany(e => e.Mentions).HasForeignKey(e => e.CommentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
