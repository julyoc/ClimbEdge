using ClimbEdge.Domain.Entities.Organizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Organizations
{
    internal class OrganizationFileConfiguration : IEntityTypeConfiguration<OrganizationFile>
    {
        public void Configure(EntityTypeBuilder<OrganizationFile> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.FileName).IsRequired();
            builder.Property(e => e.FileUrl).IsRequired();
            builder.HasOne(e => e.Organization).WithMany(e => e.Files).HasForeignKey(e => e.OrganizationId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
