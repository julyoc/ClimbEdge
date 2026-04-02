using ClimbEdge.Domain.Entities.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Comments
{
    internal class CommentAttachmentConfiguration : IEntityTypeConfiguration<CommentAttachment>
    {
        public void Configure(EntityTypeBuilder<CommentAttachment> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.FileName).IsRequired();
            builder.Property(e => e.FileUrl).IsRequired();
            builder.HasOne(e => e.Comment).WithMany(e => e.Attachments).HasForeignKey(e => e.CommentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
