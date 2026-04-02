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
    public class RouteFileConfiguration : IEntityTypeConfiguration<RouteFile>
    {
        public void Configure(EntityTypeBuilder<RouteFile> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(mf => mf.FileType)
                   .IsRequired();
            builder.Property(mf => mf.FileName)
                   .IsRequired()
                   .HasMaxLength(255);
            builder.Property(mf => mf.FileSize)
                   .IsRequired();
            builder.Property(mf => mf.FileUrl)
                   .IsRequired()
                   .HasMaxLength(2048);

            builder.HasOne(e => e.MountainRoute)
                   .WithMany(e => e.RouteFiles)
                   .HasForeignKey(e => e.MountainRouteId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.UploadedUserProfile)
                   .WithMany(e => e.RouteFiles)
                   .HasForeignKey(e => e.UploadedBy)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
