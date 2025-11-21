using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Entities.DifficultyScales;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Enums.Mountains;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Mountains
{
    public sealed class MountainRoute : BaseModel
    {
        public long MountainId { get; set; }
        public Mountain Mountain { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public RouteType Type { get; set; }
        public long DifficultyScaleId { get; set; }
        public DifficultyScale DifficultyScale { get; set; }
        /// <summary>
        /// Distance of the route in kilometers.
        /// </summary>
        public float Distance { get; set; }
        /// <summary>
        /// Elevation gain of the route in meters.
        /// </summary>
        public int? ElevationGain { get; set; }
        /// <summary>
        /// Elevation loss of the route in meters.
        /// </summary>
        public int? ElevationLoss { get; set; }
        /// <summary>
        /// Gets or sets the estimated duration of the operation, in seconds.
        /// </summary>
        public int EstimatedDuration { get; set; }
        public SeasonType BestSeason { get; set; }
        public bool RequiresPermit { get; set; } = false;
        public int? MaxParticipants { get; set; }
        /// <summary>
        /// Indica si la ruta requiere ser guiada por un profesional.
        /// </summary>
        public bool IsGuided { get; set; } = false;
        public int DangerLevel { get; set; } = 5; // Scale from 1 to 10
        public DateOnly? FirstAscentDate { get; set; }
        public string? FirstAscentBy { get; set; }
        public override void InitializeSlug()
        {
            Slug = $"{Name}-{Distance}";
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
        public IEnumerable<RouteWaypoint>? RouteWaypoints { get; set; }
        public IEnumerable<RouteTrack>? RouteTracks { get; set; }
        public IEnumerable<RouteFile>? RouteFiles { get; set; }
        public IEnumerable<MountainExpeditionLog>? MountainExpeditionLogs { get; set; }
        public IEnumerable<Expedition>? Expeditions { get; set; }
    }
}
