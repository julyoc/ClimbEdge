using ClimbEdge.Domain.Entities.Boards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Boards
{
    public class BoardItemTextureConfiguration : IEntityTypeConfiguration<BoardItemTexture>
    {
        public void Configure(EntityTypeBuilder<BoardItemTexture> builder)
        {
            builder.ConfigureBaseModel();
            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.HasIndex(b => b.Name).IsUnique();
            builder.Property(b => b.Description)
                   .HasColumnType("TEXT");
            builder.Property(b => b.ImageUrl);
            builder.Property(b => b.ThumbnailUrl);
            builder.Property(b => b.Difficulty)
                   .IsRequired();
            builder.Property(b => b.Properties)
                   .HasColumnType("JSONB")
                   .IsRequired()
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                       v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, (JsonSerializerOptions)null!)!);
        }
    }
}
