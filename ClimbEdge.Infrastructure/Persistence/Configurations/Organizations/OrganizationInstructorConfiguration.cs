using ClimbEdge.Domain.Entities.Organizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text.Json;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Organizations
{
    internal class OrganizationInstructorConfiguration : IEntityTypeConfiguration<OrganizationInstructor>
    {
        public void Configure(EntityTypeBuilder<OrganizationInstructor> builder)
        {
            builder.ConfigureBaseModel();
            builder.HasIndex(e => new { e.OrganizationId, e.UserId }).IsUnique();
            builder.Property(e => e.Specialties)
                   .HasColumnType("jsonb")
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                       v => JsonSerializer.Deserialize<Dictionary<string, object>>(v, (JsonSerializerOptions)null!)!);
            builder.Property(e => e.Languages)
                   .HasColumnType("jsonb")
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                       v => JsonSerializer.Deserialize<Dictionary<string, object>>(v, (JsonSerializerOptions)null!));
            builder.Property(e => e.AvailabilitySchedule)
                   .HasColumnType("jsonb")
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                       v => JsonSerializer.Deserialize<Dictionary<string, object>>(v, (JsonSerializerOptions)null!));
            builder.HasOne(e => e.Organization).WithMany(e => e.Instructors).HasForeignKey(e => e.OrganizationId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
