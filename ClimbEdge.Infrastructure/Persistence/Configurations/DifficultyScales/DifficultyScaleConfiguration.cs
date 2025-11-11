using ClimbEdge.Domain.Entities.DifficultyScales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.DifficultyScales
{
    internal class DifficultyScaleConfiguration : IEntityTypeConfiguration<DifficultyScale>
    {
        public void Configure(EntityTypeBuilder<DifficultyScale> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(e => e.Value).IsRequired().HasMaxLength(50);
            builder.Property(e => e.IRCRA).IsRequired();
            builder.Property(e => e.IsActive).IsRequired();
            builder.Property(e => e.ConversionTable).HasColumnType("jsonb");

            builder.HasOne(e => e.DifficultyGroup).WithMany(e => e.DifficultyScales)
                   .HasForeignKey(e => e.DifficultyGroupId).IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.PreviousVersion).WithMany(e => e.NextsVersion)
                   .HasForeignKey(e => e.PreviousVersionId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.DifficultyScaleName).WithMany(e => e.DifficultyScales)
                   .HasForeignKey(e => e.DifficultyScaleNameId).IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
