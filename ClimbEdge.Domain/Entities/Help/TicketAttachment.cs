using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Help
{
    public sealed class TicketAttachment : BaseModel
    {
        public long TicketId { get; set; }
        public SupportTicket? Ticket { get; set; }
        public long? TicketMessageId { get; set; }
        public TicketMessage? TicketMessage { get; set; }
        public string FileName { get; set; } = string.Empty;
        public FileType FileType { get; set; }
        public int FileSize { get; set; }
        public string FileUrl { get; set; } = string.Empty;
        public long UploadedBy { get; set; }
        public bool IsPublic { get; set; } = false;
        public override void InitializeSlug() => Slug = $"ticketattach-{TicketId}-{FileName}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<TicketAttachment>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<TicketAttachment>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<TicketAttachment>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<TicketAttachment>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<TicketAttachment>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
