using ClimbEdge.Domain.Entities.Boards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Boards
{
    public class BoardConfigConfiguration : IEntityTypeConfiguration<BoardConfig>
    {
        public void Configure(EntityTypeBuilder<BoardConfig> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(bc => bc.Name)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.HasIndex(bc => bc.Name).IsUnique();
            builder.Property(bc => bc.Description)
                   .HasColumnType("TEXT");
            builder.Property(bc => bc.Version)
                   .IsRequired();
            builder.Property(bc => bc.IsActive);
            builder.Property(bc => bc.Content)
                   .IsRequired()
                   .HasColumnType("TEXT");
            builder.Property(bc => bc.Cols)
                   .IsRequired();
            builder.Property(bc => bc.Rows)
                   .IsRequired();
            builder.Property(bc => bc.Width)
                   .IsRequired();
            builder.Property(bc => bc.Height)
                   .IsRequired();
            builder.Property(bc => bc.InterItemSpacingVertical)
                   .IsRequired();
            builder.Property(bc => bc.InterItemSpacingHorizontal)
                   .IsRequired();
            builder.Property(bc => bc.IsStaggeredGrid);
            builder.Property(bc => bc.StaggeredGridOffset);
            builder.Property(bc => bc.Difficulty);
            builder.HasIndex(b => new { b.CreatedByUserId, b.IsActive });
            builder.Property(b => b.ApprovedAt);
            builder.Property(b => b.ChangeNotes)
                   .HasColumnType("TEXT");
            builder.Property(b => b.IsBackwardCompatible);
            builder.Property(b => b.MigrationScript)
                   .HasColumnType("TEXT");


            // Relaciones
            builder.HasOne(bc => bc.PreviousVersion)
                   .WithMany(bc => bc.NextVersions)
                   .HasForeignKey(bc => bc.PreviousVersionId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(bc => bc.CreatedByUser)
                   .WithMany(u => u.CreatedBoardConfigs)
                   .HasForeignKey(bc => bc.CreatedByUserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(bc => bc.ApprovedByUser)
                   .WithMany(bc => bc.ApprovedBoardConfigs)
                   .HasForeignKey(bc => bc.ApprovedByUserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
