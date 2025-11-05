using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Boards.Problems
{
    public sealed class BoardProblemItem : BaseModel
    {
        public  int? Sequence { get; set; }
        public long BoardProblemId { get; set; }
        public BoardProblem BoardProblem { get; set; }
        public long BoardItemId { get; set; }
        public BoardItem BoardItem { get; set; }
        public long BoardProblemItemTypeId { get; set; }
        public BoardProblemItemType BoardProblemItemType { get; set; }
        public override void InitializeSlug()
        {
            Slug = $"{BoardProblemId}-{BoardItemId}-{BoardProblemItemTypeId}";
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<BoardProblemItem>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<BoardProblemItem>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<BoardProblemItem>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<BoardProblemItem>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<BoardProblemItem>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
    }
}
