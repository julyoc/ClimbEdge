using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Climbing
{
    public sealed class ClimbZoneFile : BaseModel
    {
        public long ClimbZoneId { get; set; }
        public ClimbZone? ClimbZone { get; set; }
        public bool IsSketch { get; set; } = false;
        public string FileName { get; set; } = string.Empty;
        public FileType FileType { get; set; }
        public int FileSize { get; set; }
        public string FileUrl { get; set; } = string.Empty;
        public string[]? FileResourceUrl { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? Description { get; set; }
        public override void InitializeSlug() => Slug = $"{FileName}-{ClimbZoneId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<ClimbZoneFile>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<ClimbZoneFile>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<ClimbZoneFile>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<ClimbZoneFile>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<ClimbZoneFile>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
