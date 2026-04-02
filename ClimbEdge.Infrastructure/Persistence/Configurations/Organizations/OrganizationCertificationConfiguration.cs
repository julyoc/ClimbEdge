using ClimbEdge.Domain.Entities.Organizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Organizations
{
    internal class OrganizationCertificationConfiguration : IEntityTypeConfiguration<OrganizationCertification>
    {
        public void Configure(EntityTypeBuilder<OrganizationCertification> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.CertificationName).IsRequired();
            builder.HasOne(e => e.Organization).WithMany().HasForeignKey(e => e.OrganizationId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
