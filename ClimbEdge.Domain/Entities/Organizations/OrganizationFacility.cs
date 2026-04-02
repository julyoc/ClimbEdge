using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Organizations
{
    public sealed class OrganizationFacility : BaseModel
    {
        public long OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string FacilityType { get; set; } = string.Empty;
        public int? Capacity { get; set; }
        public decimal? Area { get; set; }
        public decimal? Height { get; set; }
        public bool IsActive { get; set; } = true;
        public bool RequiresReservation { get; set; } = false;
        public IDictionary<string, object>? Equipment { get; set; }
        public IDictionary<string, object>? SafetyFeatures { get; set; }
        public string? AccessLevel { get; set; }
        public IEnumerable<OrganizationEvent>? Events { get; set; }
        public override void InitializeSlug() => Slug = $"{Name}-{OrganizationId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<OrganizationFacility>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<OrganizationFacility>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<OrganizationFacility>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<OrganizationFacility>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<OrganizationFacility>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
