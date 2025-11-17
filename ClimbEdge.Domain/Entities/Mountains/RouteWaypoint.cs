using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Mountains
{
    public sealed class RouteWaypoint : BaseModel
    {
        public long MountainRouteId { get; set; }
        public MountainRoute? MountainRoute { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Point Location { get; set; }
        public int Elevation { get; set; } // in meters
        public int Sequence { get; set; }
        public long WaypointTypeId { get; set; }
        public WaypointType? WaypointType { get; set; }
        public int EstimatedTimeFromPrevious { get; set; } // in minutes
        public string? Notes { get; set; }
        public string[]? ImageUrl { get; set; }
        public override void InitializeSlug()
        {
            Slug = $"{Name}-{MountainRouteId}-{Sequence}";
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<RouteWaypoint>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<RouteWaypoint>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<RouteWaypoint>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<RouteWaypoint>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<RouteWaypoint>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
    }
}
