using System.ComponentModel;

namespace ClimbEdge.Domain.Enums
{
    /// <summary>
    /// Prioridades de tickets de soporte
    /// </summary>
    public enum TicketPriority
    {
        /// <summary>
        /// Prioridad baja
        /// </summary>
        Low,

        /// <summary>
        /// Prioridad normal
        /// </summary>
        Normal,

        /// <summary>
        /// Prioridad alta
        /// </summary>
        High,

        /// <summary>
        /// Prioridad urgente
        /// </summary>
        Urgent,

        /// <summary>
        /// Prioridad crítica
        /// </summary>
        Critical
    }
}
