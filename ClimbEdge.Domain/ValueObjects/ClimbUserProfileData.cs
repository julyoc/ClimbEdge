using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.ValueObjects
{
    public class ClimbUserProfileData
    {
        /// <summary>
        /// Nivel de experiencia en escalada
        /// </summary>
        public string? ClimbingExperienceLevel { get; set; }
        /// <summary>
        /// Estilo de escalada preferido
        /// </summary>
        public string? PreferredClimbingStyle { get; set; }
        /// <summary>
        /// Número de emergencia
        /// </summary>
        public string? EmergencyContact { get; set; }
        /// <summary>
        /// Nombre del contacto de emergencia
        /// </summary>
        public string? EmergencyContactName { get; set; }
    }
}
