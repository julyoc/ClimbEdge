using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Entities.Boards;
using ClimbEdge.Domain.Enums.Mountains;
using ClimbEdge.Domain.Shared;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Mountains
{
    public sealed class Mountain : BaseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public MountainType Type { get; set; }
        /// <summary>
        /// Elevation of the mountain peak in meters.
        /// </summary>
        public int Elevation { get; set; } // in meters
        /// <summary>
        /// Coordenadas geográficas usando PostGIS (latitud, longitud).
        /// </summary>
        public Point Location { get; set; }
        public string Country { get; set; }
        public string? Region { get; set; }
        public string? State { get; set; }
        public DateOnly? FirstAscentDate { get; set; }
        public string? FirstAscentBy { get; set; }
        /// <summary>
        /// Indica si la montaña está disponible para actividades.
        /// </summary>
        public bool IsActive { get; set; } = true;
        public short DifficultyRating { get; set; } // Scale from 1 to 10
        public string[]? ImageUrls { get; set; }
        public override void InitializeSlug()
        {
            Slug = Name;
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<Mountain>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<Mountain>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<Mountain>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<Mountain>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<Mountain>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
        public IEnumerable<MountainRoute>? Routes { get; set; }
        public IEnumerable<MountainFile>? MountainFiles { get; set; }
        }
}
