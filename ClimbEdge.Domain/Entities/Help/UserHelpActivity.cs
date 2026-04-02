using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Help
{
    public sealed class UserHelpActivity : BaseModel
    {
        public long UserId { get; set; }
        public string ActivityType { get; set; } = string.Empty;
        public string EntityType { get; set; } = string.Empty;
        public long EntityId { get; set; }
        public string? Details { get; set; }
        public int? Duration { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
        public override void InitializeSlug() => Slug = $"helpactivity-{UserId}-{ActivityType}-{EntityType}-{EntityId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<UserHelpActivity>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<UserHelpActivity>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<UserHelpActivity>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<UserHelpActivity>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<UserHelpActivity>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
