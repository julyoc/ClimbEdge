namespace ClimbEdge.Application.DTOs
{
    public record class CreateCommentDTO
    {
        public long AuthorId { get; set; }
        public string EntityType { get; set; } = string.Empty;
        public long EntityId { get; set; }
        public long? ParentCommentId { get; set; }
        public string Content { get; set; } = string.Empty;
    }

    public record class UpdateCommentDTO
    {
        public string Content { get; set; } = string.Empty;
    }

    public record class GetCommentDTO : BaseDTO
    {
        public long AuthorId { get; set; }
        public string EntityType { get; set; } = string.Empty;
        public long EntityId { get; set; }
        public long? ParentCommentId { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsEdited { get; set; }
        public DateTime? EditedAt { get; set; }
        public bool IsPinned { get; set; }
    }
}
