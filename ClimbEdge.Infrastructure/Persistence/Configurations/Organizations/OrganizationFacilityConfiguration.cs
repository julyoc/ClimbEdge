using ClimbEdge.Domain.Entities.Organizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text.Json;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Organizations
{
    internal class OrganizationFacilityConfiguration : IEntityTypeConfiguration<OrganizationFacility>
    {
        public void Configure(EntityTypeBuilder<OrganizationFacility> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Equipment)
                   .HasColumnType("jsonb")
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                       v => JsonSerializer.Deserialize<Dictionary<string, object>>(v, (JsonSerializerOptions)null!));
            builder.Property(e => e.SafetyFeatures)
                   .HasColumnType("jsonb")
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                       v => JsonSerializer.Deserialize<Dictionary<string, object>>(v, (JsonSerializerOptions)null!));
            builder.HasOne(e => e.Organization).WithMany(e => e.Facilities).HasForeignKey(e => e.OrganizationId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
