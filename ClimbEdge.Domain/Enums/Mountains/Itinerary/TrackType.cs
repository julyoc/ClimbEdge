using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Enums.Mountains.Itinerary
{
    public enum TrackType
    {
        /// <summary>
        /// Expedición completa.
        /// </summary>
        Complete_Expedition,
        /// <summary>
        /// Intento de cumbre.
        /// </summary>
        Summit_Attempt,
        /// <summary>
        /// Bucle de aclimatación.
        /// </summary>
        Acclimatization_Loop,
        /// <summary>
        /// Sección de aproximación.
        /// </summary>
        Approach_Section
    }
}
