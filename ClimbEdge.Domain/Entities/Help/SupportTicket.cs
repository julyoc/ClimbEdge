using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums.Help;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Help
{
    public sealed class SupportTicket : BaseModel
    {
        public string TicketNumber { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TicketCategory Category { get; set; }
        public TicketPriority Priority { get; set; }
        public TicketStatus Status { get; set; }
        public long CreatedByUserId { get; set; }
        public long? AssignedToUserId { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public DateTime? FirstResponseAt { get; set; }
        public DateTime LastActivityAt { get; set; }
        public int? EstimatedResolutionTime { get; set; }
        public int? ActualResolutionTime { get; set; }
        public int? CustomerSatisfactionRating { get; set; }
        public string? ResolutionNotes { get; set; }
        public IEnumerable<TicketMessage>? Messages { get; set; }
        public IEnumerable<TicketAttachment>? Attachments { get; set; }
        public override void InitializeSlug() => Slug = TicketNumber.ToLower();
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<SupportTicket>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<SupportTicket>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<SupportTicket>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<SupportTicket>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<SupportTicket>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
