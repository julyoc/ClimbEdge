using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums.Payment;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Payment
{
    public sealed class Subscription : BaseModel
    {
        public long UserId { get; set; }
        public long PlanId { get; set; }
        public Plan? Plan { get; set; }
        public SubscriptionStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? NextBillingDate { get; set; }
        public bool AutoRenew { get; set; } = true;
        public DateTime? CancelledAt { get; set; }
        public string? CancellationReason { get; set; }
        public IEnumerable<global::ClimbEdge.Domain.Entities.Payment.Payment>? Payments { get; set; }
        public override void InitializeSlug() => Slug = $"subscription-{UserId}-{PlanId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<Subscription>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<Subscription>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<Subscription>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<Subscription>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<Subscription>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
