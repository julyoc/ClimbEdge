using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Help
{
    public sealed class ChatMessage : BaseModel
    {
        public long SessionId { get; set; }
        public LiveChatSession? Session { get; set; }
        public long SenderId { get; set; }
        public string Message { get; set; } = string.Empty;
        public string MessageType { get; set; } = string.Empty;
        public bool IsFromAgent { get; set; } = false;
        public bool IsSystemMessage { get; set; } = false;
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; } = false;
        public string? AttachmentUrl { get; set; }
        public override void InitializeSlug() => Slug = $"chatmsg-{SessionId}-{SenderId}-{Timestamp:yyyyMMddHHmmss}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<ChatMessage>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<ChatMessage>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<ChatMessage>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<ChatMessage>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<ChatMessage>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
