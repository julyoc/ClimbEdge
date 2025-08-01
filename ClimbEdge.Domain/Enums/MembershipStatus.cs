using System.ComponentModel;

namespace ClimbEdge.Domain.Enums
{
    /// <summary>
    /// Estados de membresía en organizaciones
    /// </summary>
    public enum MembershipStatus
    {
        /// <summary>
        /// Membresía activa
        /// </summary>
        Active,

        /// <summary>
        /// Membresía inactiva
        /// </summary>
        Inactive,

        /// <summary>
        /// Membresía suspendida
        /// </summary>
        Suspended,

        /// <summary>
        /// Membresía expirada
        /// </summary>
        Expired,

        /// <summary>
        /// Membresía cancelada
        /// </summary>
        Cancelled,

        /// <summary>
        /// Membresía pendiente de aprobación
        /// </summary>
        Pending
    }
}
