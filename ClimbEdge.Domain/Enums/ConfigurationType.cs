using System.ComponentModel;

namespace ClimbEdge.Domain.Enums
{
    /// <summary>
    /// Tipos de configuración del sistema
    /// </summary>
    public enum ConfigurationType
    {
        /// <summary>
        /// Configuración de tablero
        /// </summary>
        BoardConfig,

        /// <summary>
        /// Plan de entrenamiento
        /// </summary>
        TrainingPlan,

        /// <summary>
        /// Escala de dificultad
        /// </summary>
        DifficultyScale,

        /// <summary>
        /// Configuración de organización
        /// </summary>
        Organization,

        /// <summary>
        /// Configuración del sistema
        /// </summary>
        System,

        /// <summary>
        /// Preferencias de usuario
        /// </summary>
        UserPreferences
    }
}
