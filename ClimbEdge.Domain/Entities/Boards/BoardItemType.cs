using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Boards
{
    public sealed class BoardItemType : BaseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Difficulty { get; set; }
        public string? Icon { get; set; }
        public BoardItemType() { }
        public override void InitializeSlug()
        {
            Slug = Name.ToLower().Replace(" ", "-");
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<BoardItemType>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<BoardItemType>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<BoardItemType>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<BoardItemType>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<BoardItemType>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
        public IEnumerable<BoardItem>? BoardItems { get; set; }
        }
}
