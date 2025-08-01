using System.ComponentModel;

namespace ClimbEdge.Domain.Enums
{
    /// <summary>
    /// Zonas de entrenamiento basadas en frecuencia cardíaca máxima
    /// </summary>
    public enum TrainingZone
    {
        /// <summary>
        /// Zona de descanso (&lt;55% FCM)
        /// </summary>
        Rest,

        /// <summary>
        /// Zona aeróbica ligera (55-75% FCM)
        /// </summary>
        Zone1,

        /// <summary>
        /// Zona aeróbica moderada (75-80% FCM)
        /// </summary>
        Zone2,

        /// <summary>
        /// Zona anaeróbica (80-90% FCM)
        /// </summary>
        Zone3,

        /// <summary>
        /// Zona anaeróbica alta (90-95% FCM)
        /// </summary>
        Zone4,

        /// <summary>
        /// Zona máxima (&gt;95% FCM)
        /// </summary>
        Zone5
    }
}
