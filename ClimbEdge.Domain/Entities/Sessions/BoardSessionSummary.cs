using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Entities.Boards;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Sessions
{
    public sealed class BoardSessionSummary : BaseModel
    {
        public long BoardId { get; set; }
        public Board? Board { get; set; }
        public long UserId { get; set; }
        public UserProfile? User { get; set; }
        public int TotalSessions { get; set; } = 0;
        public int TotalProblemsCompleted { get; set; } = 0;
        public int TotalAttempts { get; set; } = 0;
        public int? AttemptNumber { get; set; }
        public int? SentOnAttempt { get; set; }
        public override void InitializeSlug() => Slug = $"{BoardId}-{UserId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<BoardSessionSummary>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<BoardSessionSummary>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<BoardSessionSummary>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<BoardSessionSummary>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<BoardSessionSummary>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
