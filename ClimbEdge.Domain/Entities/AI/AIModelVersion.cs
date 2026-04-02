using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.AI
{
    public sealed class AIModelVersion : BaseModel
    {
        public long AIModelId { get; set; }
        public AIModel? AIModel { get; set; }
        public string VersionNumber { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? TrainingDataVersion { get; set; }
        public string? ModelFile { get; set; }
        public string Metrics { get; set; } = "{}";
        public bool IsActive { get; set; } = false;
        public bool IsDeprecated { get; set; } = false;
        public DateTime ReleaseDate { get; set; }
        public DateTime? TrainingStartDate { get; set; }
        public DateTime? TrainingEndDate { get; set; }
        public IEnumerable<AIGenerationRequest>? GenerationRequests { get; set; }
        public IEnumerable<AIModelBenchmark>? Benchmarks { get; set; }
        public override void InitializeSlug() => Slug = $"aimodelversion-{AIModelId}-{VersionNumber}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<AIModelVersion>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<AIModelVersion>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<AIModelVersion>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<AIModelVersion>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<AIModelVersion>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
