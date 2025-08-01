using System.ComponentModel;

namespace ClimbEdge.Domain.Enums
{
    /// <summary>
    /// Tipos de uso para las presas de escalada
    /// </summary>
    public enum HoldUsage
    {
        /// <summary>
        /// Se puede usar como pie y mano
        /// </summary>
        Both,

        /// <summary>
        /// Solo se puede usar como mano
        /// </summary>
        HandOnly,

        /// <summary>
        /// Solo se puede usar como pie
        /// </summary>
        FootOnly
    }
}
