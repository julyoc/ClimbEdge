using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums.Payment;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Payment
{
    public sealed class Payment : BaseModel
    {
        public long UserId { get; set; }
        public long? SubscriptionId { get; set; }
        public Subscription? Subscription { get; set; }
        public long? PayPerUseId { get; set; }
        public PayPerUse? PayPerUse { get; set; }
        public long PaymentMethodId { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public PaymentStatus Status { get; set; }
        public string TransactionId { get; set; } = string.Empty;
        public DateTime? ProcessedAt { get; set; }
        public string? FailureReason { get; set; }
        public DateTime? RefundedAt { get; set; }
        public decimal? RefundAmount { get; set; }
        public IEnumerable<InvoiceItem>? InvoiceItems { get; set; }
        public override void InitializeSlug() => Slug = $"payment-{UserId}-{TransactionId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<Payment>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<Payment>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<Payment>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<Payment>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<Payment>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
