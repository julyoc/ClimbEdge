using System.ComponentModel;

namespace ClimbEdge.Domain.Enums
{
    /// <summary>
    /// Tipos de periodos de entrenamiento
    /// </summary>
    public enum TrainingPeriodType
    {
        /// <summary>
        /// Periodo de acondicionamiento general (6-8 semanas)
        /// </summary>
        Transition,

        /// <summary>
        /// Periodo de entrenamiento base (20 semanas)
        /// </summary>
        Base,

        /// <summary>
        /// Periodo específico de escalada
        /// </summary>
        Specific,

        /// <summary>
        /// Periodo de descanso antes del objetivo
        /// </summary>
        Tapering
    }
}
