using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums.AI;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.AI
{
    public sealed class AIModel : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public AIModelType Type { get; set; }
        public string Version { get; set; } = string.Empty;
        public string Parameters { get; set; } = "{}";
        public bool IsActive { get; set; } = true;
        public long? ModelSize { get; set; }
        public long? TrainingDataSize { get; set; }
        public decimal? AccuracyScore { get; set; }
        public DateTime? LastTrainedAt { get; set; }
        public DateTime? DeployedAt { get; set; }
        public string? ResourceRequirements { get; set; }
        public IEnumerable<AIModelVersion>? Versions { get; set; }
        public IEnumerable<AIModelConfiguration>? Configurations { get; set; }
        public IEnumerable<AIModelLog>? Logs { get; set; }
        public IEnumerable<AIGenerationRequest>? GenerationRequests { get; set; }
        public IEnumerable<AITrainingSession>? TrainingSessions { get; set; }
        public IEnumerable<AIGenerationTemplate>? GenerationTemplates { get; set; }
        public IEnumerable<AIModelBenchmark>? Benchmarks { get; set; }
        public override void InitializeSlug() => Slug = $"{Name.ToLower().Replace(" ", "-")}-{Version}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<AIModel>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<AIModel>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<AIModel>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<AIModel>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<AIModel>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
