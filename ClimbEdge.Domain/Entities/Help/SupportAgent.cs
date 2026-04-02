using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Help
{
    public sealed class SupportAgent : BaseModel
    {
        public long UserId { get; set; }
        public string AgentLevel { get; set; } = string.Empty;
        public string? Specializations { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsAvailable { get; set; } = false;
        public int MaxConcurrentChats { get; set; } = 3;
        public int CurrentActiveChats { get; set; } = 0;
        public int TotalTicketsResolved { get; set; } = 0;
        public decimal? AverageResolutionTime { get; set; }
        public decimal? AverageRating { get; set; }
        public DateTime? LastActiveAt { get; set; }
        public override void InitializeSlug() => Slug = $"agent-{UserId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<SupportAgent>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<SupportAgent>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<SupportAgent>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<SupportAgent>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<SupportAgent>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
