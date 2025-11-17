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
    internal class DifficultyScaleTypeConfiguration : IEntityTypeConfiguration<DifficultyScaleType>
    {
        public void Configure(EntityTypeBuilder<DifficultyScaleType> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasIndex(e => e.Name).IsUnique();
        }
    }
}
