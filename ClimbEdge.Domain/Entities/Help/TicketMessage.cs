using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Help
{
    public sealed class TicketMessage : BaseModel
    {
        public long TicketId { get; set; }
        public SupportTicket? Ticket { get; set; }
        public long SenderId { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsInternalNote { get; set; } = false;
        public bool IsSystemMessage { get; set; } = false;
        public string MessageType { get; set; } = string.Empty;
        public string? Attachments { get; set; }
        public override void InitializeSlug() => Slug = $"ticketmsg-{TicketId}-{SenderId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<TicketMessage>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<TicketMessage>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<TicketMessage>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<TicketMessage>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<TicketMessage>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
