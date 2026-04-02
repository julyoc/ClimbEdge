using ClimbEdge.Domain.Entities.Organizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Organizations
{
    internal class OrganizationEventConfiguration : IEntityTypeConfiguration<OrganizationEvent>
    {
        public void Configure(EntityTypeBuilder<OrganizationEvent> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.Title).IsRequired();
            builder.HasOne(e => e.Organization).WithMany(e => e.Events).HasForeignKey(e => e.OrganizationId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
