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
    public class MountainRouteConfiguration : IEntityTypeConfiguration<MountainRoute>
    {
        public void Configure(EntityTypeBuilder<MountainRoute> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.Property(e => e.Description).HasMaxLength(1000);
            builder.Property(e => e.Type)
                   .IsRequired();
            builder.Property(e => e.Distance)
                   .IsRequired();
            builder.Property(e => e.EstimatedDuration)
                   .IsRequired();
            builder.Property(e => e.BestSeason)
                   .IsRequired();
            builder.Property(e => e.RequiresPermit)
                   .IsRequired()
                   .HasDefaultValue(false);
            builder.Property(e => e.IsGuided).IsRequired().HasDefaultValue(false);
            builder.Property(e => e.DangerLevel)
                   .IsRequired().HasDefaultValue(5);

            builder.HasOne(e => e.Mountain)
                   .WithMany(m => m.Routes)
                   .HasForeignKey(e => e.MountainId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.DifficultyScale)
                   .WithMany(e => e.MountainRoutes)
                   .HasForeignKey(e => e.DifficultyScaleId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
