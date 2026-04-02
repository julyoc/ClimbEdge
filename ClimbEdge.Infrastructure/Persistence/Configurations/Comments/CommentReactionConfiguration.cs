using ClimbEdge.Domain.Entities.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Comments
{
    internal class CommentReactionConfiguration : IEntityTypeConfiguration<CommentReaction>
    {
        public void Configure(EntityTypeBuilder<CommentReaction> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.ReactionType).IsRequired();
            builder.HasIndex(e => new { e.CommentId, e.UserId, e.ReactionType }).IsUnique();
            builder.HasOne(e => e.Comment).WithMany(e => e.Reactions).HasForeignKey(e => e.CommentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
