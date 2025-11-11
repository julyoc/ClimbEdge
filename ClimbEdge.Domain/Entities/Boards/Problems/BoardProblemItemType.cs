using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums.Boards;
using ClimbEdge.Domain.Shared;
using ClimbEdge.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Boards.Problems
{
    public sealed class BoardProblemItemType : BaseModel
    {
        public long ColorId { get; set; }
        public HoldUsage Usage { get; set; } = HoldUsage.Both;
        public bool IsStart { get; set; }
        public bool IsEnd { get; set; }
        public bool IsZone { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsTouchOnly { get; set; }
        public int Difficulty { get; set; }
        public override void InitializeSlug()
        {
            Slug = $"{Difficulty}-{Usage}-{IsStart}-{IsEnd}-{IsZone}-{IsMandatory}-{IsTouchOnly}";
        }
        public IEnumerable<BoardProblemItem>? BoardProblemItems { get; set; }
        public Color? Color { get; set; }

        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<BoardProblemItemType>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<BoardProblemItemType>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<BoardProblemItemType>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<BoardProblemItemType>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<BoardProblemItemType>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
    }
}
