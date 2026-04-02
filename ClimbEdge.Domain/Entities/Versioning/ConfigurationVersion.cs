using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Versioning
{
    public sealed class ConfigurationVersion : BaseModel
    {
        public string EntityType { get; set; } = string.Empty;
        public long EntityId { get; set; }
        public int VersionNumber { get; set; }
        public string Content { get; set; } = string.Empty;
        public string? ChangeDescription { get; set; }
        public long ChangedByUserId { get; set; }
        public bool IsCurrentVersion { get; set; } = false;
        public IEnumerable<VersionDependency>? Dependencies { get; set; }
        public override void InitializeSlug() => Slug = $"{EntityType}-{EntityId}-v{VersionNumber}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<ConfigurationVersion>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<ConfigurationVersion>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<ConfigurationVersion>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<ConfigurationVersion>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<ConfigurationVersion>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
