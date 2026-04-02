using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.AI
{
    public sealed class AIGenerationHistory : BaseModel
    {
        public long AIGenerationRequestId { get; set; }
        public AIGenerationRequest? AIGenerationRequest { get; set; }
        public long AIModelVersionId { get; set; }
        public AIModelVersion? AIModelVersion { get; set; }
        public string Step { get; set; } = string.Empty;
        public string StepData { get; set; } = "{}";
        public int Duration { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Message { get; set; }
        public DateTime Timestamp { get; set; }
        public override void InitializeSlug() => Slug = $"aigenhistory-{AIGenerationRequestId}-{Step}-{Timestamp:yyyyMMddHHmmss}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<AIGenerationHistory>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<AIGenerationHistory>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<AIGenerationHistory>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<AIGenerationHistory>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<AIGenerationHistory>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
