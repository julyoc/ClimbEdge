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
            builder.HasData(
                new DifficultyGroup { Id = 1, Level = 1, Name = "Beginner", Description = "Suitable for beginners.", Slug = "beginner"},
                new DifficultyGroup { Id = 2, Level = 2, Name = "Intermediate", Description = "Suitable for intermediate climbers." , Slug = "intermediate"},
                new DifficultyGroup { Id = 3, Level = 3, Name = "Advanced", Description = "Suitable for advanced climbers." , Slug = "advanced"},
                new DifficultyGroup { Id = 4, Level = 4, Name = "Expert", Description = "Suitable for expert climbers." , Slug = "expert"},
                new DifficultyGroup { Id = 5, Level = 5, Name = "Elite", Description = "Suitable for elite climbers." , Slug = "elite"}
            );
        }
    }
}
