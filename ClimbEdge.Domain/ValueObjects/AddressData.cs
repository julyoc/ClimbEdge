using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.ValueObjects
{
    public record AddressData
    (
        string? Reference,
        string[]? Street,
        string? City,
        string? State,
        string? ZipCode,
        string Country
    );
}
