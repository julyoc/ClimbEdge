using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums.Notifications;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Notifications
{
    public sealed class Notification : BaseModel
    {
        public long UserId { get; set; }
        public long? TemplateId { get; set; }
        public NotificationTemplate? Template { get; set; }
        public NotificationType Type { get; set; }
        public string? Subject { get; set; }
        public string Message { get; set; } = string.Empty;
        public NotificationStatus Status { get; set; }
        public DateTime? SentAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public DateTime? ReadAt { get; set; }
        public string? FailureReason { get; set; }
        public string? ExternalId { get; set; }
        public string NotificationMetadata { get; set; } = "{}";
        public IEnumerable<NotificationQueue>? QueueEntries { get; set; }
        public IEnumerable<NotificationLog>? Logs { get; set; }
        public override void InitializeSlug() => Slug = $"notification-{UserId}-{Type}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<Notification>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<Notification>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<Notification>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<Notification>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<Notification>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
