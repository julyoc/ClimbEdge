using ClimbEdge.Domain.Entities.Help;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Help
{
    internal class HelpArticleAttachmentConfiguration : IEntityTypeConfiguration<HelpArticleAttachment>
    {
        public void Configure(EntityTypeBuilder<HelpArticleAttachment> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.FileName).IsRequired();
            builder.Property(e => e.FileUrl).IsRequired();
            builder.HasOne(e => e.Article).WithMany(e => e.Attachments).HasForeignKey(e => e.ArticleId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
