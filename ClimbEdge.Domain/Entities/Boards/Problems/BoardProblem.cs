using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Boards.Problems
{
    public sealed class BoardProblem : BaseModel
    {
        public long BoardConfigId { get; set; }
        public BoardConfig? BoardConfig { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsPublic { get; set; } = true;
        public bool IsFeatured { get; set; } = false;
        public bool IsArchived { get; set; } = false;
        public bool IsDryTooling { get; set; } = false;
        public long? CreatedByUserId { get; set; }
        public UserProfile? CreatedByUser { get; set; }
        public bool GeneratedByAI { get; set; } = false;
        public BoardProblem() { }
        public override void InitializeSlug()
        {
            Slug = Name;
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<BoardProblem>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<BoardProblem>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<BoardProblem>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<BoardProblem>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<BoardProblem>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
        public IEnumerable<BoardProblemAngle>? BoardProblemAngles { get; set; }
        public IEnumerable<BoardProblemItem>? BoardProblemItems { get; set; }
        public IEnumerable<BoardProblemTag>? BoardProblemTags { get; set; }
        public IEnumerable<FootRule>? FootRules { get; set; }
    }
}
