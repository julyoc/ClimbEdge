using System.ComponentModel;

namespace ClimbEdge.Domain.Enums.Mountains.Itinerary
{
    /// <summary>
    /// Roles de los participantes en una expedición
    /// </summary>
    public enum ParticipantRole
    {
        /// <summary>
        /// Guía certificado
        /// </summary>
        Guide,

        /// <summary>
        /// Líder de expedición
        /// </summary>
        Leader,

        /// <summary>
        /// Participante
        /// </summary>
        Participant,

        /// <summary>
        /// Asistente
        /// </summary>
        Assistant,

        /// <summary>
        /// Médico
        /// </summary>
        Medic,

        /// <summary>
        /// Cocinero
        /// </summary>
        Cook,

        /// <summary>
        /// Porteador
        /// </summary>
        Porter
    }
}
