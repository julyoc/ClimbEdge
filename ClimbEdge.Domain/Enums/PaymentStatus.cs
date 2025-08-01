using System.ComponentModel;

namespace ClimbEdge.Domain.Enums
{
    /// <summary>
    /// Estados de pago en el sistema
    /// </summary>
    public enum PaymentStatus
    {
        /// <summary>
        /// Pago pendiente de procesamiento
        /// </summary>
        Pending,

        /// <summary>
        /// Pago en proceso de verificación
        /// </summary>
        Processing,

        /// <summary>
        /// Pago completado exitosamente
        /// </summary>
        Completed,

        /// <summary>
        /// Pago falló por algún motivo
        /// </summary>
        Failed,

        /// <summary>
        /// Pago cancelado por el usuario
        /// </summary>
        Cancelled,

        /// <summary>
        /// Pago reembolsado
        /// </summary>
        Refunded,

        /// <summary>
        /// Pago en disputa o controversia
        /// </summary>
        Disputed
    }
}
