using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.AI
{
    public sealed class AIModelBenchmark : BaseModel
    {
        public long AIModelId { get; set; }
        public AIModel? AIModel { get; set; }
        public long AIModelVersionId { get; set; }
        public AIModelVersion? AIModelVersion { get; set; }
        public string BenchmarkName { get; set; } = string.Empty;
        public string TestDataset { get; set; } = string.Empty;
        public int TestCount { get; set; }
        public int SuccessCount { get; set; }
        public int FailureCount { get; set; }
        public decimal AverageGenerationTime { get; set; }
        public decimal AccuracyScore { get; set; }
        public decimal PrecisionScore { get; set; }
        public decimal RecallScore { get; set; }
        public decimal F1Score { get; set; }
        public string CustomMetrics { get; set; } = "{}";
        public DateTime TestDate { get; set; }
        public string? Notes { get; set; }
        public override void InitializeSlug() => Slug = $"benchmark-{AIModelId}-{BenchmarkName.ToLower().Replace(" ", "-")}-{TestDate:yyyyMMdd}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<AIModelBenchmark>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<AIModelBenchmark>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<AIModelBenchmark>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<AIModelBenchmark>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<AIModelBenchmark>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
