using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums.Help;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Help
{
    public sealed class EscalationRule : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TicketCategory? Category { get; set; }
        public TicketPriority? Priority { get; set; }
        public int TimeThreshold { get; set; }
        public long? EscalateToUserId { get; set; }
        public string? EscalateToLevel { get; set; }
        public bool IsActive { get; set; } = true;
        public string Conditions { get; set; } = "{}";
        public override void InitializeSlug() => Slug = Name.ToLower().Replace(" ", "-");
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<EscalationRule>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<EscalationRule>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<EscalationRule>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<EscalationRule>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<EscalationRule>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
