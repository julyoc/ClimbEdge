using ClimbEdge.Domain.Enums.Boards;

namespace ClimbEdge.Application.DTOs
{
    public record class CreateBoardProblemDTO
    {
        public long BoardConfigId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsPublic { get; set; } = true;
        public bool IsDryTooling { get; set; } = false;
        public long? CreatedByUserId { get; set; }
    }

    public record class UpdateBoardProblemDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsFeatured { get; set; }
        public bool? IsDryTooling { get; set; }
    }

    public record class GetBoardProblemDTO : BaseDTO
    {
        public long BoardConfigId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsPublic { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsArchived { get; set; }
        public bool IsDryTooling { get; set; }
        public long? CreatedByUserId { get; set; }
        public bool GeneratedByAI { get; set; }
    }
}
