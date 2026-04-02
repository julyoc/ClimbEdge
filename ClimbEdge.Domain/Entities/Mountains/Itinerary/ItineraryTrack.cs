using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums.Mountains.Itinerary;
using ClimbEdge.Domain.Shared;
using NetTopologySuite.Geometries;

namespace ClimbEdge.Domain.Entities.Mountains.Itinerary
{
    public sealed class ItineraryTrack : BaseModel
    {
        public long? ExpeditionId { get; set; }
        public Expedition? Expedition { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TrackType TrackType { get; set; }
        public int StartDayNumber { get; set; }
        public int EndDayNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public LineString? PlannedRoute { get; set; }
        public LineString? ActualRoute { get; set; }
        public decimal? PlannedDistance { get; set; }
        public decimal? ActualDistance { get; set; }
        public int? PlannedDuration { get; set; }
        public int? ActualDuration { get; set; }
        public int? MinElevation { get; set; }
        public int? MaxElevation { get; set; }
        public int? CumulativeElevationGain { get; set; }
        public int? CumulativeElevationLoss { get; set; }
        public long? RecordedBy { get; set; }
        public string? GpsDevice { get; set; }
        public decimal? Accuracy { get; set; }
        public string? Notes { get; set; }
        public bool IsOfficial { get; set; } = false;
        public long? BasedOnRouteTrackId { get; set; }
        public decimal? RouteDeviation { get; set; }
        public decimal? CompletionPercentage { get; set; }
        public string? WeatherSummary { get; set; }
        public string? DifficultySummary { get; set; }
        public IEnumerable<MountainExpeditionLog>? MountainExpeditionLogs { get; set; }
        public IEnumerable<ItineraryDayTrack>? DayTracks { get; set; }
        public override void InitializeSlug() => Slug = $"{Name}-{ExpeditionId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<ItineraryTrack>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<ItineraryTrack>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<ItineraryTrack>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<ItineraryTrack>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<ItineraryTrack>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
