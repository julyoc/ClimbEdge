using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Enums.Mountains.Itinerary;
using ClimbEdge.Domain.Shared;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Mountains
{
    /// <summary>
    /// Itinerary log for mountain expeditions.
    /// </summary>
    public sealed class MountainExpeditionLog : BaseModel
    {
        public long? ExpeditionId { get; set; }
        public Expedition? Expedition { get; set; }
        public long? UserId { get; set; }
        public UserProfile? User {  get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Duración en minutos
        /// </summary>
        public int? Duration {  get; set; }
        public int? MaxElevationReached { get; set; }
        public int? MinElevationReached { get; set; }
        public string? WeatherConditions { get; set; }
        public string[]? Notes { get; set; }
        public string Name { get; set; }
        public string? Content { get; set; }
        public string? Description { get; set; }
        public LineString? RouteTaken { get; set; }
        public IDictionary<string, object>? Photos { get; set; }
        /// <summary>
        /// Desafios o problemas enfrentados.
        /// </summary>
        public string[]? ChallengesFaced { get; set; }
        public string[]? EquipmentUsed { get; set; }
        public string? WeatherAtSummit {  get; set; }
        public bool IsSuccessfull { get; set; } = true;
        public MountaineerTickType TickType { get; set; }
        public int? GroupSize { get; set; }
        public long? GuideId { get; set; }
        public UserProfile? Guide { get; set; }
        public IDictionary<string, object>? SafetyIncidents { get; set; }
        public long? MountainRouteId { get; set; }
        public MountainRoute? MountainRoute { get; set; }
        public long? ItineraryTrackId { get; set; }
        public ItineraryTrack? ItineraryTrack { get; set; }
        public override void InitializeSlug()
        {
            Slug = $"{Name}-{ExpeditionId}-{StartDate:yyyyMMddHHmm}";
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<MountainExpeditionLog>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<MountainExpeditionLog>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<MountainExpeditionLog>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<MountainExpeditionLog>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<MountainExpeditionLog>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
    }
}
