using ClimbEdge.Domain.Entities.Help;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Help
{
    internal class HelpArticleConfiguration : IEntityTypeConfiguration<HelpArticle>
    {
        public void Configure(EntityTypeBuilder<HelpArticle> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.Title).IsRequired();
            builder.HasOne(e => e.Category).WithMany(e => e.Articles).HasForeignKey(e => e.CategoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
