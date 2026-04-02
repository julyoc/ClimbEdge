using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Help
{
    public sealed class HelpFeedback : BaseModel
    {
        public long? UserId { get; set; }
        public string EntityType { get; set; } = string.Empty;
        public long EntityId { get; set; }
        public string FeedbackType { get; set; } = string.Empty;
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public bool IsAnonymous { get; set; } = false;
        public string? IpAddress { get; set; }
        public override void InitializeSlug() => Slug = $"helpfeedback-{EntityType}-{EntityId}-{FeedbackType}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<HelpFeedback>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<HelpFeedback>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<HelpFeedback>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<HelpFeedback>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<HelpFeedback>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
