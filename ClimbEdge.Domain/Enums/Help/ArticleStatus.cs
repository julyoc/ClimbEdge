using System.ComponentModel;

namespace ClimbEdge.Domain.Enums.Help
{
    /// <summary>
    /// Estados de artículos de ayuda
    /// </summary>
    public enum ArticleStatus
    {
        /// <summary>
        /// Artículo en borrador
        /// </summary>
        Draft,

        /// <summary>
        /// Artículo en revisión
        /// </summary>
        Review,

        /// <summary>
        /// Artículo publicado
        /// </summary>
        Published,

        /// <summary>
        /// Artículo archivado
        /// </summary>
        Archived,

        /// <summary>
        /// Artículo obsoleto
        /// </summary>
        Deprecated
    }
}
