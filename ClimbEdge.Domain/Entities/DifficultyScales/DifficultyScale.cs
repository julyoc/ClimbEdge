using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Entities.Boards.Problems;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
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
        /// <summary>
        /// en roca La escala IRCRA es la escala oficial creada por la International Rock Climbing Research Association para estandarizar la dificultad de escalada en todo el mundo.
        /// en los otros tipos es para estandarizar la dificultad relativa dentro de ese tipo de escalada.
        /// </summary>
        public int IRCRA { get; set; }
        public long? DifficultyGroupId { get; set; }
        public DifficultyGroup? DifficultyGroup { get; set; }
        public string? Description { get; set; }
        public override void InitializeSlug()
        {
            Slug = $"{Value}-{IRCRA}-{DifficultyScaleNameId}";
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
        public IEnumerable<Mountains.MountainRoute>? MountainRoutes { get; set; }
        public IEnumerable<ExpeditionLevelScales>? ExpeditionLevelScales { get; set; }
        public IEnumerable<Expedition>? Expeditions { get; set; }
    }
}
