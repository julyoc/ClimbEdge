using ClimbEdge.Domain.Entities.Mountains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Mountains
{
    internal class RouteTrackConfiguration : IEntityTypeConfiguration<RouteTrack>
    {
        public void Configure(EntityTypeBuilder<RouteTrack> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(e => e.Name)
                   .IsRequired();
            builder.Property(e => e.TrackData).HasGeoZ();
            builder.Property(e => e.TotalDistance)
                   .IsRequired();
            builder.Property(e => e.MinElevation).IsRequired();
            builder.Property(e => e.MaxElevation).IsRequired();

            builder.HasIndex(e => new { e.MountainRouteId, e.Name })
                   .IsUnique();

            builder.HasOne(e => e.MountainRoute)
                   .WithMany(r => r.RouteTracks)
                   .HasForeignKey(e => e.MountainRouteId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
