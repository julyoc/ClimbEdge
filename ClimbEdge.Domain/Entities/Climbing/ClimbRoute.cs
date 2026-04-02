using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Entities.DifficultyScales;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Climbing
{
    public sealed class ClimbRoute : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long DifficultyScaleId { get; set; }
        public DifficultyScale? DifficultyScale { get; set; }
        public long DifficultyScaleNameId { get; set; }
        public DifficultyScaleName? DifficultyScaleName { get; set; }
        public long? ClimbTagId { get; set; }
        public ClimbTag? ClimbTag { get; set; }
        public int? PitchCount { get; set; }
        public DateTime? FirstAscentDate { get; set; }
        public long? ClimbZoneId { get; set; }
        public ClimbZone? ClimbZone { get; set; }
        public IEnumerable<ClimbRouteDescription>? Descriptions { get; set; }
        public IEnumerable<ClimbRouteFile>? Files { get; set; }
        public IEnumerable<RockFeatures>? RockFeatures { get; set; }
        public override void InitializeSlug() => Slug = $"{Name}-{DifficultyScaleId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<ClimbRoute>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<ClimbRoute>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<ClimbRoute>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<ClimbRoute>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<ClimbRoute>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
