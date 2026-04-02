using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Entities.Boards;
using ClimbEdge.Domain.Entities.Boards.Problems;
using ClimbEdge.Domain.Entities.Climbing;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Enums.Mountains.Itinerary;
using ClimbEdge.Domain.Enums.Sessions;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Sessions
{
    public sealed class UserSessionProgress : BaseModel
    {
        public long UserSessionId { get; set; }
        public UserSession? UserSession { get; set; }
        public long? ClimbRouteId { get; set; }
        public ClimbRoute? ClimbRoute { get; set; }
        public long? BoardProblemId { get; set; }
        public BoardProblem? BoardProblem { get; set; }
        public long? BoardAngleId { get; set; }
        public BoardAngle? BoardAngle { get; set; }
        public long? FootRuleId { get; set; }
        public FootRule? FootRule { get; set; }
        public long? MountainRouteId { get; set; }
        public MountainRoute? MountainRoute { get; set; }
        public ClimbTickType? ClimbTickType { get; set; }
        public MountaineerTickType? MountaineerTickType { get; set; }
        public bool IsCompleted { get; set; } = false;
        public int? Duration { get; set; }
        public DateTime? TryAt { get; set; }
        public int? MaxElevationReached { get; set; }
        public string? WeatherConditions { get; set; }
        public override void InitializeSlug() => Slug = $"{UserSessionId}-{TryAt?.Ticks ?? CreatedAt.Ticks}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<UserSessionProgress>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<UserSessionProgress>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<UserSessionProgress>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<UserSessionProgress>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<UserSessionProgress>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
