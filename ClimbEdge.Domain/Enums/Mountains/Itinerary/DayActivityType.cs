using System.ComponentModel;

namespace ClimbEdge.Domain.Enums.Mountains.Itinerary
{
    /// <summary>
    /// Tipos de actividades durante un día de expedición
    /// </summary>
    public enum DayActivityType
    {
        /// <summary>
        /// Ascenso
        /// </summary>
        Ascent,

        /// <summary>
        /// Descenso
        /// </summary>
        Descent,

        /// <summary>
        /// Descanso
        /// </summary>
        Rest,

        /// <summary>
        /// Aclimatación
        /// </summary>
        Acclimatization,

        /// <summary>
        /// Viaje/Aproximación
        /// </summary>
        Travel,

        /// <summary>
        /// Montaje de campamento
        /// </summary>
        Setup,

        /// <summary>
        /// Recuperación
        /// </summary>
        Recovery,

        /// <summary>
        /// Espera por clima
        /// </summary>
        Weather_Wait
    }
}
