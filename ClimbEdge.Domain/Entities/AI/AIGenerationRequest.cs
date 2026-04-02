using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums.AI;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.AI
{
    public sealed class AIGenerationRequest : BaseModel
    {
        public long RequestedByUserId { get; set; }
        public long AIModelId { get; set; }
        public AIModel? AIModel { get; set; }
        public long? AIModelVersionId { get; set; }
        public AIModelVersion? AIModelVersion { get; set; }
        public int? Difficulty { get; set; }
        public string? Description { get; set; }
        public AIGenerationStatus Status { get; set; }
        public long? GeneratedBoardProblemId { get; set; }
        public decimal? Cost { get; set; }
        public string? Currency { get; set; }
        public bool IsPaid { get; set; } = false;
        public string? ErrorMessage { get; set; }
        public int? GenerationTimeMs { get; set; }
        public decimal? QualityScore { get; set; }
        public string? InputParameters { get; set; }
        public string? OutputMetadata { get; set; }
        public DateTime? CompletedAt { get; set; }
        public IEnumerable<AIGenerationFeedback>? Feedbacks { get; set; }
        public IEnumerable<AIGenerationHistory>? History { get; set; }
        public override void InitializeSlug() => Slug = $"aigenreq-{RequestedByUserId}-{AIModelId}-{CreatedAt:yyyyMMddHHmm}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<AIGenerationRequest>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<AIGenerationRequest>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<AIGenerationRequest>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<AIGenerationRequest>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<AIGenerationRequest>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
