using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Help
{
    public sealed class HelpSearchLog : BaseModel
    {
        public long? UserId { get; set; }
        public string SearchQuery { get; set; } = string.Empty;
        public int ResultCount { get; set; }
        public long? ClickedArticleId { get; set; }
        public string? SessionId { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
        public DateTime SearchDate { get; set; }
        public bool? WasHelpful { get; set; }
        public override void InitializeSlug() => Slug = $"helpsearch-{SearchDate:yyyyMMddHHmmss}-{SearchQuery.Replace(" ", "-")[..Math.Min(20, SearchQuery.Length)]}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<HelpSearchLog>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<HelpSearchLog>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<HelpSearchLog>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<HelpSearchLog>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<HelpSearchLog>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
