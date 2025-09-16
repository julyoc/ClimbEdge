using System.ComponentModel;

namespace ClimbEdge.Domain.Enums.Mountains.Itinerary
{
    /// <summary>
    /// Tipos de tickets o registros para montañistas
    /// </summary>
    public enum MountaineerTickType
    {
        /// <summary>
        /// Cima alcanzada exitosamente
        /// </summary>
        Summit,

        /// <summary>
        /// Intentado, pero no se alcanzó la cumbre (retirada por clima, fatiga, etc.)
        /// </summary>
        Attempted,

        /// <summary>
        /// Ascenso planificado, aún no intentado
        /// </summary>
        Planned,

        /// <summary>
        /// Expedición abandonada antes o durante el intento
        /// </summary>
        Abandoned,

        /// <summary>
        /// Intento fallido por causas externas o físicas
        /// </summary>
        Failed,

        /// <summary>
        /// Se necesitó rescate o evacuación
        /// </summary>
        Rescue,

        /// <summary>
        /// Cima ya alcanzada previamente, ruta repetida
        /// </summary>
        Repeat
    }
}
