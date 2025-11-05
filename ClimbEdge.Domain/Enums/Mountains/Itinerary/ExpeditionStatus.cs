using System.ComponentModel;

namespace ClimbEdge.Domain.Enums.Mountains.Itinerary
{
    /// <summary>
    /// Estados de una expedición
    /// </summary>
    public enum ExpeditionStatus
    {
        /// <summary>
        /// En planificación
        /// </summary>
        Planning,

        /// <summary>
        /// Programada
        /// </summary>
        Scheduled,

        /// <summary>
        /// En curso
        /// </summary>
        InProgress,

        /// <summary>
        /// Completada
        /// </summary>
        Completed,

        /// <summary>
        /// Cancelada
        /// </summary>
        Cancelled,

        /// <summary>
        /// Pospuesta
        /// </summary>
        Postponed,

        /// <summary>
        /// Situación de emergencia
        /// </summary>
        Emergency
    }
}
