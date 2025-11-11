using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.ValueObjects
{
    public sealed record ColorRgb
    (
        short RgbRed,
        short RgbGreen,
        short RgbBlue
    )
    {
        public static ColorRgb FromHex(ColorHex hex)
        {
            string clean = hex.HexCode.Replace("#", "").Trim();
            if (clean.Length != 6)
                throw new ArgumentException("El código hexadecimal debe tener 6 caracteres.");

            short r = Convert.ToInt16(clean.Substring(0, 2), 16);
            short g = Convert.ToInt16(clean.Substring(2, 2), 16);
            short b = Convert.ToInt16(clean.Substring(4, 2), 16);

            return new ColorRgb(r, g, b);
        }

        public ColorHsl ToHsl()
        {
            double r = RgbRed / 255.0;
            double g = RgbGreen / 255.0;
            double b = RgbBlue / 255.0;

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double h, s, l;
            h = s = l = (max + min) / 2.0;

            if (max == min)
            {
                h = s = 0; // gris
            }
            else
            {
                double d = max - min;
                s = l > 0.5 ? d / (2 - max - min) : d / (max + min);

                if (max == r)
                    h = (g - b) / d + (g < b ? 6 : 0);
                else if (max == g)
                    h = (b - r) / d + 2;
                else
                    h = (r - g) / d + 4;

                h /= 6;
            }

            return new ColorHsl(
                (int)Math.Round(h * 360),
                (int)Math.Round(s * 100),
                (int)Math.Round(l * 100)
            );
        }
    }
    public sealed record ColorHsl
    (
        int HslHue,
        int HslSaturation,
        int HslLightness
    );
    public sealed record ColorHex
    (
        string HexCode
    )
    {
        public ColorRgb ToRgb() => ColorRgb.FromHex(this);
    }
}
