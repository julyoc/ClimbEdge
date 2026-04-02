using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums.Notifications;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Notifications
{
    public sealed class NotificationTemplate : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string? Subject { get; set; }
        public string Body { get; set; } = string.Empty;
        public NotificationType Type { get; set; }
        public string Language { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public string Variables { get; set; } = "{}";
        public IEnumerable<Notification>? Notifications { get; set; }
        public override void InitializeSlug() => Slug = Name.ToLower().Replace(" ", "-");
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<NotificationTemplate>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<NotificationTemplate>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<NotificationTemplate>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<NotificationTemplate>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<NotificationTemplate>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
