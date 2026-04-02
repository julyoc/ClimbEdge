using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.AI
{
    public sealed class AIGenerationTemplate : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public long AIModelId { get; set; }
        public AIModel? AIModel { get; set; }
        public string TemplateParameters { get; set; } = "{}";
        public string DifficultyRange { get; set; } = string.Empty;
        public string? ProblemStyle { get; set; }
        public bool IsPublic { get; set; } = false;
        public long CreatedByUserId { get; set; }
        public int UsageCount { get; set; } = 0;
        public decimal? SuccessRate { get; set; }
        public override void InitializeSlug() => Slug = Name.ToLower().Replace(" ", "-");
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<AIGenerationTemplate>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<AIGenerationTemplate>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<AIGenerationTemplate>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<AIGenerationTemplate>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<AIGenerationTemplate>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
