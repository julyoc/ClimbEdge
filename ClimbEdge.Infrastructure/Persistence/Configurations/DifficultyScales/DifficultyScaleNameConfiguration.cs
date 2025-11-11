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
    internal class DifficultyScaleNameConfiguration : IEntityTypeConfiguration<DifficultyScaleName>
    {
        public void Configure(EntityTypeBuilder<DifficultyScaleName> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasIndex(e => e.Name).IsUnique();

            builder.HasOne(e => e.DifficultyScaleType).WithMany(e => e.DifficultyScaleNames).HasForeignKey(e => e.DifficultyScaleTypeId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
