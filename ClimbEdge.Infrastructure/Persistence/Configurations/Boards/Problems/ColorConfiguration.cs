using ClimbEdge.Domain.Entities.Boards.Problems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Persistence.Configurations.Boards.Problems
{
    internal class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ConfigureBaseModel();

            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.DisplayName).IsRequired().HasMaxLength(100);
            builder.OwnsOne(e => e.ColorHex, e =>
            {
                e.Property(e => e.HexCode).IsRequired();
                e.HasIndex(e => e.HexCode).IsUnique();
            });
            builder.OwnsOne(e => e.ColorRgb, e =>
            {
                e.Property(e => e.RgbRed).IsRequired();
                e.Property(e => e.RgbGreen).IsRequired();
                e.Property(e => e.RgbBlue).IsRequired();

                e.HasIndex(e => new { e.RgbRed, e.RgbGreen, e.RgbBlue }).IsUnique();
            });
            builder.OwnsOne(e => e.ColorHsl, e =>
            {
                e.Property(e => e.HslHue).IsRequired();
                e.Property(e => e.HslSaturation).IsRequired();
                e.Property(e => e.HslLightness).IsRequired();

                e.HasIndex(e => new { e.HslHue, e.HslSaturation, e.HslLightness }).IsUnique();
            });
            builder.Property(e => e.IsStandard).IsRequired();

            builder.Ignore(e => e.HexCode);
            builder.Ignore(e => e.Rgb);
            builder.Ignore(e => e.Hsl);

            builder.HasIndex(e => e.Name).IsUnique();
            builder.HasIndex(e => e.DisplayName).IsUnique();
        }
    }
}
