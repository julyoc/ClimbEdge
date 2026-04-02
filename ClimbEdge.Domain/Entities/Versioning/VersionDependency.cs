using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Versioning
{
    public sealed class VersionDependency : BaseModel
    {
        public long ConfigurationVersionId { get; set; }
        public ConfigurationVersion? ConfigurationVersion { get; set; }
        public string DependencyEntityType { get; set; } = string.Empty;
        public long DependencyEntityId { get; set; }
        public int? RequiredVersionNumber { get; set; }
        public string? DependencyType { get; set; }
        public string? Notes { get; set; }
        public override void InitializeSlug() => Slug = $"dep-{ConfigurationVersionId}-{DependencyEntityType}-{DependencyEntityId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<VersionDependency>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<VersionDependency>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<VersionDependency>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<VersionDependency>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<VersionDependency>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
