using System.ComponentModel;

namespace ClimbEdge.Domain.Enums.Boards
{
    /// <summary>
    /// Roles de los miembros en un tablero de escalada
    /// </summary>
    public enum BoardMemberRole
    {
        /// <summary>
        /// Propietario del tablero, tiene todos los permisos
        /// </summary>
        Owner,

        /// <summary>
        /// Administrador del tablero, puede gestionar miembros y configuraciones
        /// </summary>
        Admin,

        /// <summary>
        /// Miembro del tablero, puede ver y participar en el tablero
        /// </summary>
        Member,

        /// <summary>
        /// Solo puede ver el tablero, sin permisos de edición
        /// </summary>
        Viewer
    }
}
