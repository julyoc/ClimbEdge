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
    internal class BoardItemConfiguration : IEntityTypeConfiguration<BoardItem>
    {
        public void Configure(EntityTypeBuilder<BoardItem> builder)
        {
            builder.ConfigureBaseModel();
            
            builder.Property(b => b.Orientation)
                   .IsRequired();
            builder.Property(b => b.AllowedUsage)
                   .IsRequired();
            builder.Property(b => b.Difficulty)
                   .IsRequired();

            builder.HasIndex(b => new { b.BoardConfigId, b.PositionX, b.PositionY })
                   .IsUnique();

            builder.Property(b => b.IsDryTooling)
                   .IsRequired();

            // Relaciones
            builder.HasOne(b => b.BoardConfig)
                   .WithMany(b => b.BoardItems)
                   .HasForeignKey(b => b.BoardConfigId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b => b.BoardItemType)
                   .WithMany(b => b.BoardItems)
                   .HasForeignKey(b => b.BoardItemTypeId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b => b.BoardItemVolume)
                   .WithMany(b => b.BoardItems)
                   .HasForeignKey(b => b.BoardItemVolumeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
