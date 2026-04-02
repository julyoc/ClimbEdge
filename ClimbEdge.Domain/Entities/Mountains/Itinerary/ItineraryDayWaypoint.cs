using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Shared;
using NetTopologySuite.Geometries;

namespace ClimbEdge.Domain.Entities.Mountains.Itinerary
{
    public sealed class ItineraryDayWaypoint : BaseModel
    {
        public long ItineraryDayId { get; set; }
        public ItineraryDay? ItineraryDay { get; set; }
        public long? ItineraryDayTrackId { get; set; }
        public ItineraryDayTrack? ItineraryDayTrack { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Point Location { get; set; } = null!;
        public int Elevation { get; set; }
        public DateTime Timestamp { get; set; }
        public long WaypointTypeId { get; set; }
        public WaypointType? WaypointType { get; set; }
        public int? Duration { get; set; }
        public string? Photo { get; set; }
        public string? Notes { get; set; }
        public long? RecordedBy { get; set; }
        public string? WeatherConditions { get; set; }
        public decimal? Temperature { get; set; }
        public bool IsPlanned { get; set; } = false;
        public bool IsEmergency { get; set; } = false;
        public override void InitializeSlug() => Slug = $"{Name}-{ItineraryDayId}-{Timestamp.Ticks}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<ItineraryDayWaypoint>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<ItineraryDayWaypoint>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<ItineraryDayWaypoint>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<ItineraryDayWaypoint>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<ItineraryDayWaypoint>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
