using System.ComponentModel;

namespace ClimbEdge.Domain.Enums
{
    /// <summary>
    /// Tipos de actividades de entrenamiento
    /// </summary>
    public enum ConfigurationKey
    {
        /// <summary>
        /// Idioma del sistema
        /// </summary>
        System_Language,
        /// <summary>
        /// Modo de mantenimiento del sistema
        /// </summary>
        System_MaintenanceMode,
        /// <summary>
        /// Tablero predeterminado del usuario
        /// </summary>
        User_DefaultBoard,
        /// <summary>
        /// Mostrar consejos al usuario
        /// </summary>
        User_ShowTips,
        /// <summary>
        /// Nombre de la escala de dificultad predeterminada para entrenamientos
        /// </summary>
        Training_DefaultDifficultyScaleName,
        /// <summary>
        /// Rango de dificultad predeterminado para entrenamientos
        /// </summary>
        Training_DefaultDifficultyRange,
        /// <summary>
        /// Rango de dificultad activo por defecto para entrenamientos
        /// </summary>
        Training_DefaultDifficultyRangeActive,
        /// <summary>
        /// Mostrar videos beta en entrenamientos
        /// </summary>
        Training_ShowBetaVideos,
        /// <summary>
        /// Cargar automáticamente la última sesión de entrenamiento
        /// </summary>
        Training_AutoLoadSession,
        /// <summary>
        /// Notificaciones por correo electrónico habilitadas
        /// </summary>
        Notification_EmailEnabled,
        /// <summary>
        /// Notificaciones push habilitadas
        /// </summary>
        Notification_PushEnabled,
        /// <summary>
        /// Inicio de horas silenciosas para notificaciones
        /// </summary>
        Notification_QuietHoursStart,
        /// <summary>
        /// Fin de horas silenciosas para notificaciones
        /// </summary>
        Notification_QuietHoursEnd,
        /// <summary>
        /// Unidades de longitud (por ejemplo, metros, pies)
        /// </summary>
        Units_Length,
        /// <summary>
        /// Unidades de peso (por ejemplo, kilogramos, libras)
        /// </summary>
        Units_Weight,
        /// <summary>
        /// Unidades de temperatura (por ejemplo, Celsius, Fahrenheit)
        /// </summary>
        Units_Temperature
    }
}
