using ClimbEdge.Domain.Entities.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Comments
{
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.EntityType).IsRequired();
            builder.Property(e => e.Content).IsRequired();
            builder.HasOne(e => e.ParentComment).WithMany(e => e.Replies).HasForeignKey(e => e.ParentCommentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
