using ClimbEdge.Domain.Entities.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Comments
{
    internal class CommentReportConfiguration : IEntityTypeConfiguration<CommentReport>
    {
        public void Configure(EntityTypeBuilder<CommentReport> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.Reason).IsRequired();
            builder.HasOne(e => e.Comment).WithMany(e => e.Reports).HasForeignKey(e => e.CommentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
