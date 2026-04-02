using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums.Mountains.Itinerary;
using ClimbEdge.Domain.Shared;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Mountains.Itinerary
{
    public sealed class ItineraryDay : BaseModel
    {
        public long ExpeditionId { get; set; }
        public Expedition? Expedition { get; set; }
        public int DayNumber { get; set; }
        public DateOnly Date { get; set; }
        public DayActivityType ActivityType { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public Point? StartLocation { get; set; }
        public Point? EndLocation { get; set; }
        public int? StartElevation { get; set; }
        public int? EndElevation { get; set; }
        /// <summary>
        /// Distance in kilometers
        /// </summary>
        public float? Distance { get; set; }
        public int? ElevationGain { get; set; }
        public int? ElevationLoss { get; set; }
        /// <summary>
        /// Estimated duration in minutes
        /// </summary>
        public int? EstimatedDuration { get; set; }
        /// <summary>
        /// Difficulty rating from 1 (easiest) to 10 (hardest)
        /// </summary>
        public int DifficultyRating { get; set; } = 5;
        public bool WeatherDependency { get; set; } = false;
        public bool IsRestDay => ActivityType == DayActivityType.Rest;
        public string[]? Notes { get; set; }
        public override void InitializeSlug()
        {
            Slug = $"{Title}-{Date.ToString("yyyyMMdd")}";
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<ItineraryDay>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<ItineraryDay>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<ItineraryDay>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<ItineraryDay>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<ItineraryDay>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
    }
}
