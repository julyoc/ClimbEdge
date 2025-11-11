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
    internal class DifficultyGroupConfiguration : IEntityTypeConfiguration<DifficultyGroup>
    {
        public void Configure(EntityTypeBuilder<DifficultyGroup> builder)
        {
            builder.ConfigureBaseModel();
            
            builder.Property(e => e.Level)
                .IsRequired();
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(e => e.Level)
                .IsUnique();
            builder.HasIndex(e => e.Name)
                .IsUnique();
        }
    }
}
