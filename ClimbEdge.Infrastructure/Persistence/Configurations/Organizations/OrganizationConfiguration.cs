using ClimbEdge.Domain.Entities.Organizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text.Json;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Organizations
{
    internal class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Location).HasGeoZ();
            builder.Property(e => e.BusinessHours)
                   .HasColumnType("jsonb")
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                       v => JsonSerializer.Deserialize<Dictionary<string, object>>(v, (JsonSerializerOptions)null!));
            builder.Property(e => e.SocialMedia)
                   .HasColumnType("jsonb")
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                       v => JsonSerializer.Deserialize<Dictionary<string, object>>(v, (JsonSerializerOptions)null!));
            builder.Property(e => e.Amenities)
                   .HasColumnType("jsonb")
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                       v => JsonSerializer.Deserialize<Dictionary<string, object>>(v, (JsonSerializerOptions)null!));
            builder.Property(e => e.SafetyCertifications)
                   .HasColumnType("jsonb")
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                       v => JsonSerializer.Deserialize<Dictionary<string, object>>(v, (JsonSerializerOptions)null!));
        }
    }
}
