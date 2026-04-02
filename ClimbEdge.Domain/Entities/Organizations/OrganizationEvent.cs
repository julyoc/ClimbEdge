using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Organizations
{
    public sealed class OrganizationEvent : BaseModel
    {
        public long OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string EventType { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Location { get; set; }
        public long? FacilityId { get; set; }
        public OrganizationFacility? Facility { get; set; }
        public int? MaxParticipants { get; set; }
        public int CurrentParticipants { get; set; } = 0;
        public DateTime? RegistrationDeadline { get; set; }
        public decimal? Cost { get; set; }
        public string? Currency { get; set; }
        public bool RequiresRegistration { get; set; } = false;
        public bool IsPublic { get; set; } = true;
        public string? SkillLevelRequired { get; set; }
        public string? Equipment { get; set; }
        public string? Instructor { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public string? CancellationPolicy { get; set; }
        public string Status { get; set; } = "Planned";
        public IEnumerable<OrganizationEventParticipant>? Participants { get; set; }
        public override void InitializeSlug() => Slug = $"{Title}-{OrganizationId}-{StartDate:yyyyMMdd}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<OrganizationEvent>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<OrganizationEvent>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<OrganizationEvent>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<OrganizationEvent>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<OrganizationEvent>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
