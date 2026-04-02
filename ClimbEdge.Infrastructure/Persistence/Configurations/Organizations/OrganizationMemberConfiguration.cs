using ClimbEdge.Domain.Entities.Organizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Organizations
{
    internal class OrganizationMemberConfiguration : IEntityTypeConfiguration<OrganizationMember>
    {
        public void Configure(EntityTypeBuilder<OrganizationMember> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasIndex(e => new { e.OrganizationId, e.UserId }).IsUnique();
            builder.HasOne(e => e.Organization).WithMany(e => e.Members).HasForeignKey(e => e.OrganizationId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
