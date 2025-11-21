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
    internal class MountainFileConfiguration : IEntityTypeConfiguration<MountainFile>
    {
        public void Configure(EntityTypeBuilder<MountainFile> builder)
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
            builder.Property(e => e.Location).HasGeoZ();

            builder.HasIndex(e => e.Location).IsGeoIndex();

            builder.HasOne(mf => mf.Mountain)
                   .WithMany(m => m.MountainFiles)
                   .HasForeignKey(mf => mf.MountainId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
