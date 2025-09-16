using System.ComponentModel;

namespace ClimbEdge.Domain.Enums.Payment
{
    /// <summary>
    /// Estados de suscripción en el sistema
    /// </summary>
    public enum SubscriptionStatus
    {
        /// <summary>
        /// Suscripción activa y vigente
        /// </summary>
        Active,

        /// <summary>
        /// Suscripción inactiva
        /// </summary>
        Inactive,

        /// <summary>
        /// Suscripción cancelada
        /// </summary>
        Cancelled,

        /// <summary>
        /// Suscripción expirada
        /// </summary>
        Expired,

        /// <summary>
        /// Suscripción suspendida temporalmente
        /// </summary>
        Suspended,

        /// <summary>
        /// Suscripción pendiente de cancelación
        /// </summary>
        PendingCancellation
    }
}
