using System.ComponentModel;

namespace ClimbEdge.Domain.Enums.AI
{
    /// <summary>
    /// Estados de generación de contenido con IA
    /// </summary>
    public enum AIGenerationStatus
    {
        /// <summary>
        /// Solicitud pendiente de procesamiento
        /// </summary>
        Pending,

        /// <summary>
        /// En cola de procesamiento
        /// </summary>
        Queued,

        /// <summary>
        /// En proceso de generación
        /// </summary>
        InProgress,

        /// <summary>
        /// Generación completada exitosamente
        /// </summary>
        Completed,

        /// <summary>
        /// Generación falló
        /// </summary>
        Failed,

        /// <summary>
        /// Generación cancelada por el usuario
        /// </summary>
        Cancelled,

        /// <summary>
        /// Requiere pago antes de procesar
        /// </summary>
        RequiresPayment,

        /// <summary>
        /// Resultado bajo revisión por calidad
        /// </summary>
        UnderReview
    }
}
