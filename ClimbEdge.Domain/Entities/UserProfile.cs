using ClimbEdge.Common.Constants;
using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;
using ClimbEdge.Domain.ValueObjects;
using System.Collections.Generic;
using System.Numerics;

namespace ClimbEdge.Domain.Entities
{
    /// <summary>
    /// Perfil de usuario con información adicional
    /// </summary>
    public class UserProfile : BaseModel
    {
        /// <summary>
        /// Identificador del usuario asociado
        /// </summary>
        public long UserId { get; set; }
        public AppUser? AppUser { get; set; }
        /// <summary>
        /// Nombre completo del usuario
        /// </summary>
        public string? FirstName { get; set; }
        /// <summary>
        /// Apellido del usuario
        /// </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// Fecha de nacimiento
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Biografía o descripción del usuario
        /// </summary>
        public string? Bio { get; set; }
        /// <summary>
        /// URL de la foto de perfil
        /// </summary>
        public string? ProfilePictureUrl { get; set; }
        /// <summary>
        /// Sitio web personal
        /// </summary>
        public string? Website { get; set; }
        /// <summary>
        /// Ubicación del usuario
        /// </summary>
        public string? Location { get; set; }
        /// <summary>
        /// País del usuario
        /// </summary>
        public string Country { get; set; } = Constants.DefaultCountry;
        /// <summary>
        /// Zona horaria del usuario
        /// </summary>
        public string TimeZone { get; set; } = Constants.DefaultTimeZone;
        /// <summary>
        /// Idioma preferido del usuario
        /// </summary>
        public string PreferredLanguage { get; set; } = Constants.DefaultLanguage;
        /// <summary>
        /// Indica si el perfil es público
        /// </summary>
        public bool IsPublic { get; set; } = true;
        /// <summary>
        /// Indica si acepta notificaciones por email
        /// </summary>
        public bool EmailNotifications { get; set; } = true;
        /// <summary>
        /// Indica si acepta notificaciones push
        /// </summary>
        public bool PushNotifications { get; set; } = true;
        public ClimbUserProfileData ClimbData { get; set; }
        /// <summary>
        /// Nombre completo calculado
        /// </summary>
        public string FullName => $"{FirstName} {LastName}".Trim();
        /// <summary>
        /// Edad calculada basada en la fecha de nacimiento
        /// </summary>
        public int? Age
        {
            get
            {
                if (!DateOfBirth.HasValue)
                    return null;

                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Value.Year;

                if (today.DayOfYear < DateOfBirth.Value.DayOfYear)
                    age--;

                return age;
            }
        }
        /// <summary>
        /// Iniciales del usuario
        /// </summary>
        public string Initials => $"{FirstName?.FirstOrDefault()}{LastName?.FirstOrDefault()}".ToUpper();

        public UserProfile() : base()
        {
            Slug = $"{Country}/{Initials}/{CreatedAt.Ticks}";
            AddDomainEvent(new EntityDomainEvent<UserProfile>(Slug, EntityDomainEventType.Created));
        }

        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<UserProfile>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<UserProfile>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<UserProfile>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<UserProfile>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<UserProfile>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
    }
}
