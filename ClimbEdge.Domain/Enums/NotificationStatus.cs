using System.ComponentModel;

namespace ClimbEdge.Domain.Enums
{
    /// <summary>
    /// Estados de notificaciones del sistema
    /// </summary>
    public enum NotificationStatus
    {
        /// <summary>
        /// Notificación pendiente de envío
        /// </summary>
        Pending,

        /// <summary>
        /// Notificación enviada
        /// </summary>
        Sent,

        /// <summary>
        /// Notificación entregada
        /// </summary>
        Delivered,

        /// <summary>
        /// Falló el envío de la notificación
        /// </summary>
        Failed,

        /// <summary>
        /// Notificación leída por el usuario
        /// </summary>
        Read,

        /// <summary>
        /// Notificación cancelada
        /// </summary>
        Cancelled
    }
}
