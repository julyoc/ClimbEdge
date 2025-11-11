using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Entities.Boards.Problems;
using ClimbEdge.Domain.Enums.Boards;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Boards
{
    public sealed class BoardItem : BaseModel
    {
        public long BoardConfigId { get; set; }
        public BoardConfig? BoardConfig { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public HoldOrientation Orientation { get; set; } = HoldOrientation.Normal;
        public HoldUsage AllowedUsage { get; set; } = HoldUsage.Both;
        public int Difficulty { get; set; }
        public long BoardItemTypeId { get; set; }
        public BoardItemType? BoardItemType { get; set; }
        public long? BoardItemVolumeId { get; set; }
        public BoardItemVolume? BoardItemVolume { get; set; }
        public bool IsDryTooling { get; set; } = false;
        public BoardItem() { }
        public override void InitializeSlug()
        {
            Slug = $"{PositionX}-{PositionY}-{BoardConfigId}".ToLower();
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<BoardItem>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<BoardItem>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<BoardItem>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<BoardItem>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<BoardItem>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
        public IEnumerable<BoardItemTextureCombination>? TextureCombinations { get; set; }
        public IEnumerable<BoardProblemItem>? BoardProblemItems { get; set; }
    }
}
