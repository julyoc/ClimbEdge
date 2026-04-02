using ClimbEdge.Domain.Entities.Help;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Help
{
    internal class HelpCategoryConfiguration : IEntityTypeConfiguration<HelpCategory>
    {
        public void Configure(EntityTypeBuilder<HelpCategory> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.Name).IsRequired();
            builder.HasIndex(e => e.Name).IsUnique();
            builder.HasOne(e => e.ParentCategory).WithMany(e => e.SubCategories).HasForeignKey(e => e.ParentCategoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
