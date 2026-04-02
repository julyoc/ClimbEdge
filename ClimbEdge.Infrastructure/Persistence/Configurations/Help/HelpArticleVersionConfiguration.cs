using ClimbEdge.Domain.Entities.Help;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Help
{
    internal class HelpArticleVersionConfiguration : IEntityTypeConfiguration<HelpArticleVersion>
    {
        public void Configure(EntityTypeBuilder<HelpArticleVersion> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasOne(e => e.Article).WithMany(e => e.Versions).HasForeignKey(e => e.ArticleId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
