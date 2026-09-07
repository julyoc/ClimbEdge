using ClimbEdge.Domain.Entities.Mountains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Mountains
{
    public class MountainConfiguration : IEntityTypeConfiguration<Mountain>
    {
        public void Configure(EntityTypeBuilder<Mountain> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(m => m.Name)
                   .IsRequired();
            builder.Property(m => m.Description)
                   .HasMaxLength(500);
            builder.Property(m => m.Type)
                   .IsRequired();
            builder.Property(m => m.Elevation)
                   .IsRequired();
            builder.Property(m => m.Location).IsRequired().HasGeoZ();
            builder.Property(m => m.Country)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(m => m.Region)
                   .HasMaxLength(100);
            builder.Property(m => m.State).HasMaxLength(100);
            builder.Property(e => e.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);
            builder.Property(e => e.DifficultyRating)
                   .IsRequired()
                   .HasDefaultValue((short)1);

            builder.HasIndex(m => m.Name).IsUnique();
            builder.HasIndex(e => e.Location).IsGeoIndex();
        }
    }
}
