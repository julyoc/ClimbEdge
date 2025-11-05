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
    internal class BoardItemTextureCombinationConfiguration : IEntityTypeConfiguration<BoardItemTextureCombination>
    {
        public void Configure(EntityTypeBuilder<BoardItemTextureCombination> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(b => b.Percentage)
                   .IsRequired();
            builder.Property(b => b.Order)
                   .IsRequired();
            builder.Property(b => b.IsPrimary)
                   .IsRequired();
            builder.Property(b => b.IsActive)
                   .IsRequired();

            builder.HasIndex(b => new { b.BoardItemId, b.BoardItemTextureId, b.BoardItemTextureMaterialId, b.Percentage, b.Order })
                   .IsUnique();
            // Relationships
            builder.HasOne(b => b.BoardItem)
                   .WithMany(bi => bi.TextureCombinations)
                   .HasForeignKey(b => b.BoardItemId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();
            builder.HasOne(b => b.BoardItemTexture)
                   .WithMany(bit => bit.TextureCombinations)
                   .HasForeignKey(b => b.BoardItemTextureId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();
            builder.HasOne(b => b.BoardItemTextureMaterial)
                   .WithMany(bitm => bitm.TextureCombinations)
                   .HasForeignKey(b => b.BoardItemTextureMaterialId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();
        }
    }
}
