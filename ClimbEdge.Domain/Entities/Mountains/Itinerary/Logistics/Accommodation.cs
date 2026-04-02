using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;
using NetTopologySuite.Geometries;

namespace ClimbEdge.Domain.Entities.Mountains.Itinerary.Logistics
{
    public sealed class Accommodation : BaseModel
    {
        public long ExpeditionId { get; set; }
        public Expedition? Expedition { get; set; }
        public long? ItineraryDayId { get; set; }
        public ItineraryDay? ItineraryDay { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public Point? Location { get; set; }
        public string? Address { get; set; }
        public int? Elevation { get; set; }
        public int? Capacity { get; set; }
        public decimal? Cost { get; set; }
        public string? Currency { get; set; }
        public string? ContactInfo { get; set; }
        public string? BookingReference { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public string? Amenities { get; set; }
        public string? Notes { get; set; }
        public override void InitializeSlug() => Slug = $"{Name}-{ExpeditionId}-{Type}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<Accommodation>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<Accommodation>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<Accommodation>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<Accommodation>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<Accommodation>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
