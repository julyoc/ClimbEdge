using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Boards
{
    public sealed class BoardItemVolume : BaseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string VolumeType { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Depth { get; set; }
        public string? ModelUrl { get; set; }
        public string? ImageUrl { get; set; }
        public string? ThumbnailUrl { get; set; }
        public int Difficulty { get; set; }
        public IDictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
        public override void InitializeSlug()
        {
            Slug = Name.ToLower().Replace(" ", "-");
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<BoardItemVolume>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<BoardItemVolume>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<BoardItemVolume>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<BoardItemVolume>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<BoardItemVolume>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
    }
}
