using System.ComponentModel;

namespace ClimbEdge.Domain.Enums.Notifications
{
    /// <summary>
    /// Tipos de notificaciones del sistema
    /// </summary>
    public enum NotificationType
    {
        /// <summary>
        /// Notificación por correo electrónico
        /// </summary>
        Email,

        /// <summary>
        /// Notificación push en dispositivos móviles
        /// </summary>
        Push,

        /// <summary>
        /// Notificación dentro de la aplicación
        /// </summary>
        InApp,

        /// <summary>
        /// Notificación por mensaje de texto
        /// </summary>
        SMS,

        /// <summary>
        /// Notificación a través de webhook
        /// </summary>
        Webhook
    }
}
