using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.AI
{
    public sealed class AITrainingSession : BaseModel
    {
        public long AIModelId { get; set; }
        public AIModel? AIModel { get; set; }
        public long? AIModelVersionId { get; set; }
        public AIModelVersion? AIModelVersion { get; set; }
        public string SessionName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public int TrainingDataCount { get; set; }
        public int ValidationDataCount { get; set; }
        public int TestDataCount { get; set; }
        public int? Epochs { get; set; }
        public int? BatchSize { get; set; }
        public decimal? LearningRate { get; set; }
        public string TrainingMetrics { get; set; } = "{}";
        public string ValidationMetrics { get; set; } = "{}";
        public string FinalMetrics { get; set; } = "{}";
        public string? LogFile { get; set; }
        public string ConfigSnapshot { get; set; } = "{}";
        public override void InitializeSlug() => Slug = $"aitrainingsession-{AIModelId}-{SessionName.ToLower().Replace(" ", "-")}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<AITrainingSession>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<AITrainingSession>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<AITrainingSession>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<AITrainingSession>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<AITrainingSession>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
