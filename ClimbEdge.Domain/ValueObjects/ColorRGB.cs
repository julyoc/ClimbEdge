using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.ValueObjects
{
    public record ColorRGB 
    (
        short Red,
        short Green,
        short Blue,
        string? Name,
        // Codigo en los leds NeoPixel
        int Code
    );
}
