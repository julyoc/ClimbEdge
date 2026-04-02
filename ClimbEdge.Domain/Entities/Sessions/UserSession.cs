using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Entities.Boards;
using ClimbEdge.Domain.Entities.Climbing;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Sessions
{
    public sealed class UserSession : BaseModel
    {
        public long UserId { get; set; }
        public UserProfile? User { get; set; }
        public long? BoardId { get; set; }
        public Board? Board { get; set; }
        public long? ClimbZoneId { get; set; }
        public ClimbZone? ClimbZone { get; set; }
        public long? MountainRouteId { get; set; }
        public MountainRoute? MountainRoute { get; set; }
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? EndedAt { get; set; }
        public string? Notes { get; set; }
        public IEnumerable<UserSessionProgress>? Progress { get; set; }
        public override void InitializeSlug() => Slug = $"{UserId}-{StartedAt.Ticks}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<UserSession>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<UserSession>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<UserSession>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<UserSession>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<UserSession>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
