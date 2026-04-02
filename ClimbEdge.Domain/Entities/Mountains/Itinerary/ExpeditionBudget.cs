using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Mountains.Itinerary
{
    public sealed class ExpeditionBudget : BaseModel
    {
        public long ExpeditionId { get; set; }
        public Expedition? Expedition { get; set; }
        public long ExpeditionBudgetCategoryId { get; set; }
        public ExpeditionBudgetCategory? ExpeditionBudgetCategory { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal PlannedCost { get; set; }
        public decimal? ActualCost { get; set; }
        public string Currency { get; set; } = "USD";
        public bool IsPaid { get; set; } = false;
        public DateTime? PaymentDate { get; set; }
        public string? Vendor { get; set; }
        public string? Notes { get; set; }
        public override void InitializeSlug() => Slug = $"{Description}-{ExpeditionId}-{ExpeditionBudgetCategoryId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<ExpeditionBudget>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<ExpeditionBudget>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<ExpeditionBudget>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<ExpeditionBudget>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<ExpeditionBudget>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
