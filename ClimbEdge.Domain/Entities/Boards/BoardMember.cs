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
    public sealed class BoardMember : BaseModel
    {
        public long BoardId { get; set; }
        public Board? Board { get; set; }
        public long UserId { get; set; }
        public UserProfile? User { get; set; }
        public bool IsPropertyOwner { get; set; } = false;
        public BoardMemberRole Role { get; set; } = BoardMemberRole.Member;
        public BoardMember() { }
        public override void InitializeSlug()
        {
            Slug = $"{BoardId}/{UserId}";
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<BoardMember>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<BoardMember>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<BoardMember>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<BoardMember>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<BoardMember>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
    }
}
