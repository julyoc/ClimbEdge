using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums.Help;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Help
{
    public sealed class HelpArticle : BaseModel
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? Summary { get; set; }
        public long CategoryId { get; set; }
        public HelpCategory? Category { get; set; }
        public long AuthorId { get; set; }
        public ArticleStatus Status { get; set; }
        public bool IsPublic { get; set; } = true;
        public bool IsFeatured { get; set; } = false;
        public int ViewCount { get; set; } = 0;
        public int LikeCount { get; set; } = 0;
        public int DislikeCount { get; set; } = 0;
        public string? SearchKeywords { get; set; }
        public DateTime? LastReviewedAt { get; set; }
        public long? LastReviewedBy { get; set; }
        public DateTime? PublishedAt { get; set; }
        public int? EstimatedReadTime { get; set; }
        public IEnumerable<HelpArticleVersion>? Versions { get; set; }
        public IEnumerable<HelpArticleAttachment>? Attachments { get; set; }
        public override void InitializeSlug() => Slug = Title.ToLower().Replace(" ", "-");
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<HelpArticle>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<HelpArticle>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<HelpArticle>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<HelpArticle>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<HelpArticle>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
