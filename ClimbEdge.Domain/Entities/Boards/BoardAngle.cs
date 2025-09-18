using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums.Boards;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Boards
{
    public sealed class BoardAngle : BaseModel
    {
        public int Angle { get; set; }
        public AngleUnit Unit { get; set; } = AngleUnit.Degrees;
        public string? Description { get; set; }
        public BoardAngle() { }
        public override void InitializeSlug()
        {
            Slug = $"{Angle}{(Unit == AngleUnit.Degrees ? "°" : "rad")}";
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<BoardAngle>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<BoardAngle>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<BoardAngle>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<BoardAngle>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<BoardAngle>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
    }
}
