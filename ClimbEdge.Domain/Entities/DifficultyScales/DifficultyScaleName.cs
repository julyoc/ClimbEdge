using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.DifficultyScales
{
    public sealed class DifficultyScaleName : BaseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public long DifficultyScaleTypeId { get; set; }
        public DifficultyScaleType? DifficultyScaleType { get; set; }
        public override void InitializeSlug()
        {
            Slug = Name;
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<DifficultyScaleName>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<DifficultyScaleName>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<DifficultyScaleName>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<DifficultyScaleName>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<DifficultyScaleName>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
        public IEnumerable<DifficultyScale>? DifficultyScales { get; set; }
    }
}
