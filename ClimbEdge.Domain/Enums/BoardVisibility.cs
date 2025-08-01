using System.ComponentModel;

namespace ClimbEdge.Domain.Enums
{
    /// <summary>
    /// Tipos de visibilidad para los tableros de escalada
    /// </summary>
    public enum BoardVisibility
    {
        /// <summary>
        /// El tablero es visible para todos los usuarios
        /// </summary>
        Public,

        /// <summary>
        /// El tablero es visible solo para los miembros del tablero
        /// </summary>
        Private,

        /// <summary>
        /// El tablero es visible para los miembros del tablero y aquellos con el enlace directo
        /// </summary>
        Protected,

        /// <summary>
        /// El tablero no es visible en la lista de tableros, pero accesible mediante enlace directo
        /// </summary>
        Hidden,

        /// <summary>
        /// El tablero está archivado y no es visible, pero se puede restaurar
        /// </summary>
        Archived
    }
}
