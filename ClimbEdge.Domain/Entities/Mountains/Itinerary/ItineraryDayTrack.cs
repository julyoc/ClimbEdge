using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;
using NetTopologySuite.Geometries;

namespace ClimbEdge.Domain.Entities.Mountains.Itinerary
{
    public sealed class ItineraryDayTrack : BaseModel
    {
        public long ItineraryDayId { get; set; }
        public ItineraryDay? ItineraryDay { get; set; }
        public long? ItineraryTrackId { get; set; }
        public ItineraryTrack? ItineraryTrack { get; set; }
        public long? ParticipantId { get; set; }
        public string? Name { get; set; }
        public LineString TrackData { get; set; } = null!;
        public LineString? PlannedRoute { get; set; }
        public decimal TotalDistance { get; set; }
        public int MovingTime { get; set; }
        public int TotalTime { get; set; }
        public int MinElevation { get; set; }
        public int MaxElevation { get; set; }
        public int ElevationGain { get; set; }
        public int ElevationLoss { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? RecordedBy { get; set; }
        public string? GpsDevice { get; set; }
        public decimal? Accuracy { get; set; }
        public string? WeatherConditions { get; set; }
        public string? Notes { get; set; }
        public bool IsOfficial { get; set; } = false;
        public IEnumerable<ItineraryDayWaypoint>? Waypoints { get; set; }
        public override void InitializeSlug() => Slug = $"daytrack-{ItineraryDayId}-{CreatedAt.Ticks}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<ItineraryDayTrack>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<ItineraryDayTrack>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<ItineraryDayTrack>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<ItineraryDayTrack>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<ItineraryDayTrack>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
