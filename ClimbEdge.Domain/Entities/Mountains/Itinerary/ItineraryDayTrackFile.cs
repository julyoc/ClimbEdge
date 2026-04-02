using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Mountains.Itinerary
{
    public sealed class ItineraryDayTrackFile : BaseModel
    {
        public long ItineraryDayTrackId { get; set; }
        public ItineraryDayTrack? ItineraryDayTrack { get; set; }
        public FileType FileType { get; set; }
        public string FileName { get; set; } = string.Empty;
        public int FileSize { get; set; }
        public string FileUrl { get; set; } = string.Empty;
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsPrimary { get; set; } = false;
        public long? UploadedBy { get; set; }
        public override void InitializeSlug() => Slug = $"{FileName}-{ItineraryDayTrackId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<ItineraryDayTrackFile>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<ItineraryDayTrackFile>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<ItineraryDayTrackFile>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<ItineraryDayTrackFile>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<ItineraryDayTrackFile>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
