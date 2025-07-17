using System.Collections.Generic;
using ClimbEdge.Domain.Enums;

namespace ClimbEdge.Domain.Shared
{
    /// <summary>
    /// Clase de metadatos para almacenar información adicional sobre las entidades
    /// </summary>
    public class Metadata
    {
        /// <summary>
        /// Identificador único para la instancia de metadatos
        /// </summary>
        public Guid MetaId { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Descripción de los metadatos
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Etiquetas asociadas con los metadatos para categorización
        /// </summary>
        public IEnumerable<string>? Tags { get; set; }
        /// <summary>
        /// Fuente de datos de los metadatos, indicando de dónde se originaron
        /// </summary>
        public IEnumerable<MetadataDatasource> Datasource { get; set; } = new[] { MetadataDatasource.User };
        /// <summary>
        /// Notas o comentarios relacionados con los metadatos, útiles para contexto adicional
        /// </summary>
        public IEnumerable<string>? Notes { get; set; }
        /// <summary>
        /// Datos adicionales que pueden almacenarse como pares clave-valor
        /// </summary>
        public Dictionary<string, Object>? AdditionalData { get; set; }
        /// <summary>
        /// Configuraciones relacionadas con los metadatos, almacenadas como pares clave-valor
        /// </summary>
        public Dictionary<string, Object>? Config { get; set; }
        /// <summary>
        /// Sobrescribe el método ToString para mejor depuración y registro
        /// </summary>
        /// <returns>Una representación en cadena de la instancia de metadatos, incluyendo sus propiedades</returns>
        public override string ToString()
        {
            return $"MetaId: {MetaId}, Description: {Description}, Tags: [{string.Join(", ", Tags ?? new List<string>())}], Datasource: [{string.Join(", ", Datasource)}], Notes: [{string.Join(", ", Notes ?? new List<string>())}], AdditionalData: [{string.Join(", ", AdditionalData!.Keys + ":" + AdditionalData!.Values.ToString())}], Config: [{string.Join(", ", Config!.Keys + ":" + Config!.Values.ToString())}]";
        }
        /// <summary>
        /// Sobrescribe el método Equals para comparar instancias de metadatos basándose en MetaId
        /// </summary>
        /// <param name="obj">El objeto a comparar con la instancia actual</param>
        /// <returns>True si el MetaId de la instancia actual coincide con el MetaId del objeto proporcionado; de lo contrario, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Metadata other)
            {
                return MetaId == other.MetaId;
            }
            return false;
        }
        /// <summary>
        /// Sobrescribe el método GetHashCode para devolver el código hash del MetaId
        /// </summary>
        /// <returns>El código hash de la propiedad MetaId, que se utiliza para búsquedas eficientes en colecciones.</returns>
        public override int GetHashCode()
        {
            return MetaId.GetHashCode();
        }
        /// <summary>
        /// Propiedad estática para proporcionar una instancia vacía de metadatos con valores por defecto
        /// </summary>
        public static Metadata Empty => new Metadata
        {
            MetaId = Guid.Empty,
            Description = string.Empty,
            Tags = new List<string>(),
            Datasource = new[] { MetadataDatasource.User },
            Notes = new List<string>(),
            AdditionalData = new Dictionary<string, Object>(),
            Config = new Dictionary<string, Object>()
        };
        /// <summary>
        /// Propiedad estática para proporcionar una instancia por defecto de metadatos con valores predefinidos
        /// </summary>
        public static Metadata Default => new Metadata
        {
            MetaId = Guid.NewGuid(),
            Description = "Metadatos por defecto",
            Tags = new List<string> { "por-defecto", "metadatos" },
            Datasource = new[] { MetadataDatasource.User },
            Notes = new List<string> { "Esta es una instancia por defecto de metadatos." },
            AdditionalData = new Dictionary<string, Object> { { "clave1", "valor1" } },
            Config = new Dictionary<string,Object> { { "claveConfig", "valorConfig" } }
        };

    }
}