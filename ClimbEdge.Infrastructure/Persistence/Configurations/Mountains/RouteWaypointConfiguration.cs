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
    internal class RouteWaypointConfiguration : IEntityTypeConfiguration<RouteWaypoint>
    {
        public void Configure(EntityTypeBuilder<RouteWaypoint> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(rw => rw.Name)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.Property(rw => rw.Description).HasMaxLength(500);
            builder.Property(e => e.Location)
                   .IsRequired().HasGeoZ();
            builder.Property(e => e.Sequence)
                   .IsRequired();
            builder.Property(e => e.EstimatedTimeFromPrevious)
                   .IsRequired();
            builder.Property(rw => rw.Notes).HasMaxLength(1000);
            builder.Property(rw => rw.ImageUrl)
                   .HasColumnType("text[]");

            builder.HasIndex(e => e.Name);
            builder.HasIndex(e => e.Location);

            builder.HasOne(rw => rw.MountainRoute).WithMany(mr => mr.RouteWaypoints)
                   .HasForeignKey(rw => rw.MountainRouteId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(rw => rw.WaypointType).WithMany(wt => wt.RouteWaypoints)
                   .HasForeignKey(rw => rw.WaypointTypeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
