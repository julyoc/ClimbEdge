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
    internal class MountainExpeditionLogConfiguration : IEntityTypeConfiguration<MountainExpeditionLog>
    {
        public void Configure(EntityTypeBuilder<MountainExpeditionLog> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(e => e.StartDate).IsRequired();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Content).HasColumnType("text");
            builder.Property(e => e.Description).HasColumnType("text");
            builder.Property(e => e.RouteTaken).HasGeoZ();
            builder.Property(e => e.Photos).HasColumnType("jsonb");
            builder.Property(e => e.IsSuccessfull).IsRequired();
            builder.Property(e => e.TickType).IsRequired();

            builder.HasIndex(e => e.Name);
            builder.HasIndex(e => e.RouteTaken).IsGeoIndex();
            
            builder.HasOne(e => e.Expedition).WithMany(e => e.MountainExpeditionLogs).HasForeignKey(e => e.ExpeditionId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.User).WithMany(e => e.MountainExpeditionLogs).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Guide).WithMany(e => e.MountainExpeditionLogsGuided).HasForeignKey(e => e.GuideId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.MountainRoute).WithMany(e => e.MountainExpeditionLogs).HasForeignKey(e => e.MountainRouteId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.ItineraryTrack).WithMany(e => e.MountainExpeditionLogs).HasForeignKey(e => e.ItineraryTrackId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
