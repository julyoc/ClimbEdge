using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums;
using ClimbEdge.Domain.Shared;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Mountains
{
    public sealed class MountainFile : BaseModel
    {
        public long MountainId { get; set; }
        public Mountain? Mountain { get; set; }
        public FileType FileType { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string FileUrl { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? TakenAt { get; set; }
        public string? TakenBy { get; set; }
        public Point? Location { get; set; }
        public int? Elevation { get; set; }
        public bool IsPublic { get; set; } = true;
        public override void InitializeSlug()
        {
            Slug = $"{FileName}-{FileType}-{FileSize}";
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<MountainFile>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<MountainFile>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<MountainFile>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<MountainFile>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<MountainFile>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
    }
}
