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
    internal class WaypointTypeConfiguration : IEntityTypeConfiguration<WaypointType>
    {
        public void Configure(EntityTypeBuilder<WaypointType> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(m => m.Name)
                   .IsRequired().HasMaxLength(100);
            builder.Property(m => m.Description)
                   .HasMaxLength(500);

            builder.HasIndex(e => e.Name);

            builder.HasIndex(m => m.Name).IsUnique();
        }
    }
}
