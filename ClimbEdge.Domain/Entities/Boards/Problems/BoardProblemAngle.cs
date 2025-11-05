using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Entities.DifficultyScales;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Boards.Problems
{
    public sealed class BoardProblemAngle : BaseModel
    {
        public long BoardProblemId { get; set; }
        public BoardProblem? BoardProblem { get; set; }
        public long BoardAngleId { get; set; }
        public BoardAngle? BoardAngle { get; set; }
        public long DifficultyScaleId { get; set; }
        public DifficultyScale? DifficultyScale { get; set; }
        public float? Rating { get; set; }
        public BoardProblemAngle() { }
        public override void InitializeSlug()
        {
            Slug = $"{BoardAngleId}-{BoardProblemId}-{DifficultyScaleId}";
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<BoardProblemAngle>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<BoardProblemAngle>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<BoardProblemAngle>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<BoardProblemAngle>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<BoardProblemAngle>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
    }
}
