using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Organizations
{
    public sealed class OrganizationInstructor : BaseModel
    {
        public long OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        public long UserId { get; set; }
        public UserProfile? User { get; set; }
        public string InstructorLevel { get; set; } = string.Empty;
        public IDictionary<string, object> Specialties { get; set; } = new Dictionary<string, object>();
        public int? YearsExperience { get; set; }
        public string? CertificationNumber { get; set; }
        public DateTime? CertificationExpiry { get; set; }
        public bool IsActive { get; set; } = true;
        public decimal? HourlyRate { get; set; }
        public string? Currency { get; set; }
        public string? Bio { get; set; }
        public IDictionary<string, object>? Languages { get; set; }
        public IDictionary<string, object>? AvailabilitySchedule { get; set; }
        public bool EmergencyTraining { get; set; } = false;
        public override void InitializeSlug() => Slug = $"{OrganizationId}-{UserId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<OrganizationInstructor>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<OrganizationInstructor>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<OrganizationInstructor>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<OrganizationInstructor>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<OrganizationInstructor>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
