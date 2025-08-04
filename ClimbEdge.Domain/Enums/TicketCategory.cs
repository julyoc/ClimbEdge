using System.ComponentModel;

namespace ClimbEdge.Domain.Enums
{
    /// <summary>
    /// Categorías de tickets de soporte
    /// </summary>
    public enum TicketCategory
    {
        /// <summary>
        /// Problema técnico
        /// </summary>
        Technical,

        /// <summary>
        /// Error en el software
        /// </summary>
        Bug,

        /// <summary>
        /// Solicitud de nueva funcionalidad
        /// </summary>
        FeatureRequest,

        /// <summary>
        /// Problema con la cuenta
        /// </summary>
        Account,

        /// <summary>
        /// Problema con pagos
        /// </summary>
        Payment,

        /// <summary>
        /// Consulta general
        /// </summary>
        General,

        /// <summary>
        /// Retroalimentación
        /// </summary>
        Feedback,

        /// <summary>
        /// Queja o reclamo
        /// </summary>
        Complaint
    }
}
