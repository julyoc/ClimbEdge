using System.ComponentModel;

namespace ClimbEdge.Domain.Enums
{
    /// <summary>
    /// Tipos de rutas de escalada y montañismo
    /// </summary>
    public enum RouteType
    {
        /// <summary>
        /// Senderismo
        /// </summary>
        Hiking,

        /// <summary>
        /// Montañismo
        /// </summary>
        Mountaineering,

        /// <summary>
        /// Escalada en roca
        /// </summary>
        RockClimbing,

        /// <summary>
        /// Escalada en hielo
        /// </summary>
        IceClimbing,

        /// <summary>
        /// Escalada mixta
        /// </summary>
        MixedClimbing,

        /// <summary>
        /// Esquí
        /// </summary>
        Skiing = 5,

        /// <summary>
        /// Snowboard
        /// </summary>
        Snowboarding,

        /// <summary>
        /// Vía ferrata
        /// </summary>
        Via_Ferrata
    }
}
