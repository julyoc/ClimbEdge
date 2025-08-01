using System.ComponentModel;

namespace ClimbEdge.Domain.Enums
{
    /// <summary>
    /// Estados de tickets de soporte
    /// </summary>
    public enum TicketStatus
    {
        /// <summary>
        /// Ticket abierto, pendiente de atención
        /// </summary>
        Open,

        /// <summary>
        /// Ticket en proceso de resolución
        /// </summary>
        InProgress,

        /// <summary>
        /// Ticket pendiente de información del usuario
        /// </summary>
        Pending,

        /// <summary>
        /// Ticket resuelto
        /// </summary>
        Resolved,

        /// <summary>
        /// Ticket cerrado
        /// </summary>
        Closed,

        /// <summary>
        /// Ticket reabierto
        /// </summary>
        Reopened = 5,

        /// <summary>
        /// Ticket escalado a nivel superior
        /// </summary>
        Escalated = 6
    }
}
