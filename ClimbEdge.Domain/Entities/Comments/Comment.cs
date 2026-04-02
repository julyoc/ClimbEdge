using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Comments
{
    public sealed class Comment : BaseModel
    {
        public long AuthorId { get; set; }
        public string EntityType { get; set; } = string.Empty;
        public long EntityId { get; set; }
        public long? ParentCommentId { get; set; }
        public Comment? ParentComment { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsEdited { get; set; } = false;
        public DateTime? EditedAt { get; set; }
        public bool IsPinned { get; set; } = false;
        public IEnumerable<Comment>? Replies { get; set; }
        public IEnumerable<CommentAttachment>? Attachments { get; set; }
        public IEnumerable<CommentMention>? Mentions { get; set; }
        public IEnumerable<CommentReaction>? Reactions { get; set; }
        public IEnumerable<CommentReport>? Reports { get; set; }
        public override void InitializeSlug() => Slug = $"comment-{AuthorId}-{EntityType}-{EntityId}-{CreatedAt.Ticks}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<Comment>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<Comment>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<Comment>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<Comment>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<Comment>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
