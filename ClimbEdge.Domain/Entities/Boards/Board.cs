using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Entities.Auditing;
using ClimbEdge.Domain.Entities.Organizations;
using ClimbEdge.Domain.Enums.Boards;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Boards
{
    public sealed class Board : BaseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public BoardVisibility Visibility { get; set; } = BoardVisibility.Private;
        public long BoardConfigId { get; set; }
        public BoardConfig? BoardConfig { get; set; }
        public long? OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        public Board() : base() { }
        public override void InitializeSlug()
        {
            Slug = $"{Name}/{Visibility}";
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<Board>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<Board>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<Board>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<Board>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<Board>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
        public IEnumerable<BoardMember>? Members { get; set; }
    }
}
