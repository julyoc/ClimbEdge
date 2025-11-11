using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Entities.Boards.Problems;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.DifficultyScales
{
    public sealed class DifficultyScale : BaseModel
    {
        public long DifficultyScaleNameId { get; set; }
        public DifficultyScaleName? DifficultyScaleName { get; set; }
        public string Value { get; set; }
        public int IRCRA { get; set; }
        public long DifficultyGroupId { get; set; }
        public DifficultyGroup? DifficultyGroup { get; set; }
        public string? Version { get; set; }
        public bool IsActive { get; set; } = true;
        public long? PreviousVersionId { get; set; }
        public DifficultyScale? PreviousVersion { get; set; }
        public IEnumerable<DifficultyScale>? NextsVersion { get; set; }
        public DateOnly? EffectiveDate { get; set; }
        public DateOnly? ExpirationDate { get; set; }
        public Dictionary<string, object>? ConversionTable { get; set; }
        public string? ChangeReason { get; set; }
        public string? ApprovedByOrganization { get; set; }
        public override void InitializeSlug()
        {
            Slug = $"{Value}-{IRCRA}";
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<DifficultyScale>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<DifficultyScale>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<DifficultyScale>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<DifficultyScale>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<DifficultyScale>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
        public IEnumerable<BoardProblemAngle>? BoardProblemAngles { get; set; }
    }
}
