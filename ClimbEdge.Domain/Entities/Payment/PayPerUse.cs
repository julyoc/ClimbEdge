using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums.Payment;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Payment
{
    public sealed class PayPerUse : BaseModel
    {
        public long UserId { get; set; }
        public string ServiceType { get; set; } = string.Empty;
        public long? ServiceId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public PaymentStatus Status { get; set; }
        public DateTime ConsumedAt { get; set; }
        public DateTime? PaidAt { get; set; }
        public string? Description { get; set; }
        public IEnumerable<Payment>? Payments { get; set; }
        public override void InitializeSlug() => Slug = $"payperuse-{UserId}-{ServiceType}-{ConsumedAt:yyyyMMdd}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<PayPerUse>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<PayPerUse>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<PayPerUse>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<PayPerUse>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<PayPerUse>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
