using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Entities.DifficultyScales;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Mountains.Itinerary
{
    public sealed class DayActivityDifficultyScale : BaseModel
    {
        public long DayActivityId { get; set; }
        public DayActivity? DayActivity { get; set; }
        public long DifficultyScaleId { get; set; }
        public DifficultyScale? DifficultyScale { get; set; }
        public string? Description { get; set; }
        public override void InitializeSlug() => Slug = $"{DayActivityId}-{DifficultyScaleId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<DayActivityDifficultyScale>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<DayActivityDifficultyScale>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<DayActivityDifficultyScale>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<DayActivityDifficultyScale>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<DayActivityDifficultyScale>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
