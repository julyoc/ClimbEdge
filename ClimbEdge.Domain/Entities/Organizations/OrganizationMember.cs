using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums.Organizations;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Organizations
{
    public sealed class OrganizationMember : BaseModel
    {
        public long OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        public long UserId { get; set; }
        public UserProfile? User { get; set; }
        public MembershipType MembershipType { get; set; }
        public MembershipStatus Status { get; set; }
        public string? Role { get; set; }
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiresAt { get; set; }
        public DateTime? LastPaymentAt { get; set; }
        public string? MembershipNumber { get; set; }
        public string? EmergencyContact { get; set; }
        public string? EmergencyPhone { get; set; }
        public string? MedicalNotes { get; set; }
        public bool WaiverSigned { get; set; } = false;
        public DateTime? WaiverSignedAt { get; set; }
        public string? Notes { get; set; }
        public override void InitializeSlug() => Slug = $"{OrganizationId}-{UserId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<OrganizationMember>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<OrganizationMember>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<OrganizationMember>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<OrganizationMember>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<OrganizationMember>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
