using System.ComponentModel;

namespace ClimbEdge.Domain.Enums.Versioning
{
    /// <summary>
    /// Estados de versión en el sistema
    /// </summary>
    public enum VersionStatus
    {
        /// <summary>
        /// Borrador, en desarrollo
        /// </summary>
        [Description("Borrador, en desarrollo")]
        Draft,

        /// <summary>
        /// En pruebas
        /// </summary>
        Testing,

        /// <summary>
        /// Versión activa en producción
        /// </summary>
        Active,

        /// <summary>
        /// Versión obsoleta pero aún funcional
        /// </summary>
        Deprecated,

        /// <summary>
        /// Versión archivada, no funcional
        /// </summary>
        Archived,

        /// <summary>
        /// Versión de rollback temporal
        /// </summary>
        Rollback
    }
}
