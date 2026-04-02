using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Entities.Organizations;
using ClimbEdge.Domain.Shared;
using NetTopologySuite.Geometries;

namespace ClimbEdge.Domain.Entities.Climbing
{
    public sealed class ClimbZone : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Point? Location { get; set; }
        public bool IsPublic { get; set; } = true;
        public bool IsIndoor { get; set; } = false;
        public string? ImageUrl { get; set; }
        public long? OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        public IEnumerable<ClimbRoute>? ClimbRoutes { get; set; }
        public IEnumerable<ClimbZoneFile>? Files { get; set; }
        public override void InitializeSlug() => Slug = Name;
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<ClimbZone>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<ClimbZone>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<ClimbZone>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<ClimbZone>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<ClimbZone>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
