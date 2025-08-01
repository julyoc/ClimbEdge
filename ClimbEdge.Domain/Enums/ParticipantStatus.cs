using System.ComponentModel;

namespace ClimbEdge.Domain.Enums
{
    /// <summary>
    /// Estados de participación en una expedición
    /// </summary>
    public enum ParticipantStatus
    {
        /// <summary>
        /// Registrado
        /// </summary>
        Registered,

        /// <summary>
        /// Confirmado
        /// </summary>
        Confirmed,

        /// <summary>
        /// Cancelado
        /// </summary>
        Cancelled,

        /// <summary>
        /// Completado
        /// </summary>
        Completed
    }
}
