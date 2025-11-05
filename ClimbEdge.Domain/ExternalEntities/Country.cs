using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.ExternalEntities
{
    public sealed record Country(
        [property: JsonPropertyName("name")] CountryName Name,
        [property: JsonPropertyName("cca2")] string Cca2,
        [property: JsonPropertyName("cca3")] string Cca3,
        [property: JsonPropertyName("currencies")] Dictionary<string, Currency> Currencies,
        // idd es el codigo de marcación internacional
        [property: JsonPropertyName("idd")] Idd Idd,
        [property: JsonPropertyName("altSpellings")] List<string> AltSpellings,
        [property: JsonPropertyName("languages")] Dictionary<string, string> Languages,
        [property: JsonPropertyName("timezones")] List<string> Timezones,
        [property: JsonPropertyName("continents")] List<string> Continents
    );

    public sealed record CountryName(
        [property: JsonPropertyName("common")] string Common,
        [property: JsonPropertyName("official")] string Official,
        // Claves dinámicas por código de idioma (ej. "eng", "jam")
        [property: JsonPropertyName("nativeName")] Dictionary<string, LocalizedName> NativeName
    );

    public sealed record LocalizedName(
        [property: JsonPropertyName("official")] string Official,
        [property: JsonPropertyName("common")] string Common
    );

    public sealed record Currency(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("symbol")] string? Symbol
    );

    public sealed record Idd(
        [property: JsonPropertyName("root")] string Root,
        [property: JsonPropertyName("suffixes")] List<string> Suffixes
    );
}
