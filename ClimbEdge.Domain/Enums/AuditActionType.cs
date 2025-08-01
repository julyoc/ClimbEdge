using System.ComponentModel;

namespace ClimbEdge.Domain.Enums
{
    /// <summary>
    /// Tipos de acciones de auditoría para el sistema de trazabilidad
    /// </summary>
    public enum AuditActionType
    {
        /// <summary>
        /// Registro creado
        /// </summary>
        Create,

        /// <summary>
        /// Registro actualizado
        /// </summary>
        Update,

        /// <summary>
        /// Registro eliminado
        /// </summary>
        Delete,

        /// <summary>
        /// Registro restaurado
        /// </summary>
        Restore,

        /// <summary>
        /// Registro bloqueado
        /// </summary>
        Lock,

        /// <summary>
        /// Registro desbloqueado
        /// </summary>
        Unlock,

        /// <summary>
        /// Inicio de sesión
        /// </summary>
        Login,

        /// <summary>
        /// Cierre de sesión
        /// </summary>
        Logout,

        /// <summary>
        /// Registro visualizado
        /// </summary>
        View,

        /// <summary>
        /// Archivo descargado
        /// </summary>
        Download,

        /// <summary>
        /// Datos exportados
        /// </summary>
        Export,

        /// <summary>
        /// Datos importados
        /// </summary>
        Import
    }
}
