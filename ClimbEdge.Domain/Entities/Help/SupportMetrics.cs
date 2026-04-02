using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Help
{
    public sealed class SupportMetrics : BaseModel
    {
        public DateTime MetricDate { get; set; }
        public int TicketsCreated { get; set; }
        public int TicketsResolved { get; set; }
        public int TicketsClosed { get; set; }
        public decimal AverageFirstResponseTime { get; set; }
        public decimal AverageResolutionTime { get; set; }
        public decimal CustomerSatisfactionScore { get; set; }
        public int ChatSessionsStarted { get; set; }
        public int ChatSessionsCompleted { get; set; }
        public decimal AverageChatWaitTime { get; set; }
        public int KnowledgeBaseViews { get; set; }
        public int FAQViews { get; set; }
        public int SearchQueries { get; set; }
        public override void InitializeSlug() => Slug = $"supportmetrics-{MetricDate:yyyyMMdd}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<SupportMetrics>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<SupportMetrics>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<SupportMetrics>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<SupportMetrics>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<SupportMetrics>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
