using System.ComponentModel;

namespace ClimbEdge.Domain.Enums
{
    /// <summary>
    /// Tipos de actividades de entrenamiento
    /// </summary>
    public enum ActivityType
    {
        /// <summary>
        /// Actividad aeróbica en zona 1-2
        /// </summary>
        Aerobic,

        /// <summary>
        /// Actividad anaeróbica en zona 3-4
        /// </summary>
        Anaerobic,

        /// <summary>
        /// Entrenamiento de fuerza máxima
        /// </summary>
        MaxStrength,

        /// <summary>
        /// Escalada alpina
        /// </summary>
        AlpineClimbing,

        /// <summary>
        /// Escalada en escuela
        /// </summary>
        SchoolClimbing,

        /// <summary>
        /// Actividad de recuperación
        /// </summary>
        Recovery,

        /// <summary>
        /// Resistencia
        /// </summary>
        Endurance,

        /// <summary>
        /// Entrenamiento técnico
        /// </summary>
        Technical
    }
}
