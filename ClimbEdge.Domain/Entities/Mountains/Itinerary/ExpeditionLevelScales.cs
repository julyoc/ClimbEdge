using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Entities.DifficultyScales;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Mountains.Itinerary
{
    public sealed class ExpeditionLevelScales : BaseModel
    {
        public long ExpeditionId { get; set; }
        public Expedition? Expedition { get; set; }
        public long DifficultyScaleId { get; set; }
        public DifficultyScale? DifficultyScale { get; set; }
        public string? Description { get; set; }
        public override void InitializeSlug()
        {
            Slug = $"{ExpeditionId}-{DifficultyScaleId}";
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<ExpeditionLevelScales>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<ExpeditionLevelScales>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<ExpeditionLevelScales>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<ExpeditionLevelScales>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<ExpeditionLevelScales>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
    }
}
