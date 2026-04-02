using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;
using NetTopologySuite.Geometries;

namespace ClimbEdge.Domain.Entities.Mountains.Itinerary.Logistics
{
    public sealed class Transportation : BaseModel
    {
        public long ExpeditionId { get; set; }
        public Expedition? Expedition { get; set; }
        public long? ItineraryDayId { get; set; }
        public ItineraryDay? ItineraryDay { get; set; }
        public string Type { get; set; } = string.Empty;
        public string? Provider { get; set; }
        public Point? Departure { get; set; }
        public Point? Arrival { get; set; }
        public string DepartureLocation { get; set; } = string.Empty;
        public string ArrivalLocation { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int? Duration { get; set; }
        public decimal? Cost { get; set; }
        public string? Currency { get; set; }
        public string? BookingReference { get; set; }
        public string? ContactInfo { get; set; }
        public string? Notes { get; set; }
        public override void InitializeSlug() => Slug = $"{Type}-{DepartureLocation}-{ArrivalLocation}-{ExpeditionId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<Transportation>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<Transportation>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<Transportation>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<Transportation>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<Transportation>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
