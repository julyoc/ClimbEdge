using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Enums.Sessions
{
    public enum ClimbTickType
    {
        /// <summary>
        /// Onsight: Primera vez que se intenta la ruta, sin información previa ni caídas.
        /// </summary>
        Onsight,
        /// <summary>
        /// Flash: Primera vez que se intenta la ruta, pero con información previa (beta).
        /// </summary>
        Flash,
        /// <summary>
        /// Redpoint: Ruta encadenada tras varios intentos anteriores.
        /// </summary>
        Redpoint,
        /// <summary>
        /// Repeat: Ruta que ya fue encadenada antes, repetida nuevamente.
        /// </summary>
        Repeat,
        /// <summary>
        /// Project: Ruta que está en proceso, aún no ha sido encadenada.
        /// </summary>
        Project,
        /// <summary>
        /// Attempt: Intento en la ruta, sin haber llegado al encadenamiento.
        /// </summary>
        Attempt,
        /// <summary>
        /// Toprope: Ruta encadenada o intentada en top rope (no líder). [no aplica en boulder]
        /// </summary>
        Toprope,
        /// <summary>
        /// Dogged: Ruta encadenada con descansos (colgado de la cuerda). [no aplica en boulder]
        /// </summary>
        Dogged,
        /// <summary>
        /// Fell: El usuario se cayó intentando la ruta.
        /// </summary>
        Fell,
        /// <summary>
        /// Abandoned: El usuario decidió no continuar intentando la ruta.
        /// </summary>
        Abandoned
    }
}
