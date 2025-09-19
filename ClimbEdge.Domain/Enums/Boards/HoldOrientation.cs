using System.ComponentModel;

namespace ClimbEdge.Domain.Enums.Boards
{
    /// <summary>
    /// Orientación de las presas de escalada
    /// </summary>
    public enum HoldOrientation
    {
        /// <summary>
        /// Orientación normal de la presa
        /// </summary>
        Normal,

        /// <summary>
        /// Presa invertida (undercling)
        /// </summary>
        Undercling,

        /// <summary>
        /// Presa lateral (sidepull)
        /// </summary>
        Sidepull,

        /// <summary>
        /// Presa en diagonal (diagonal)
        /// </summary>
        Diagonal,
        /// <summary>
        /// Presa en diagonal invertida (diagonal undercling)
        /// </summary>
        DiagonalUndercling
    }
}
