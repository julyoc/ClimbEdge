using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;
using NetTopologySuite.Geometries;

namespace ClimbEdge.Domain.Entities.Mountains.Itinerary
{
    public sealed class DayActivity : BaseModel
    {
        public long ItineraryDayId { get; set; }
        public ItineraryDay? ItineraryDay { get; set; }
        public int Sequence { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public string ActivityName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Point? Location { get; set; }
        public int? Elevation { get; set; }
        public int? EstimatedDuration { get; set; }
        public bool IsOptional { get; set; } = false;
        public string? RequiredEquipment { get; set; }
        public string? SafetyNotes { get; set; }
        public string? AlternativePlan { get; set; }
        public IEnumerable<DayActivityDifficultyScale>? DifficultyScales { get; set; }
        public override void InitializeSlug() => Slug = $"{ActivityName}-{ItineraryDayId}-{Sequence}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<DayActivity>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<DayActivity>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<DayActivity>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<DayActivity>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<DayActivity>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
