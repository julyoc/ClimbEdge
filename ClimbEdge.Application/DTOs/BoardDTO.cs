using ClimbEdge.Domain.Enums.Boards;

namespace ClimbEdge.Application.DTOs
{
    public record class CreateBoardDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public BoardVisibility Visibility { get; set; } = BoardVisibility.Private;
        public long BoardConfigId { get; set; }
        public long? OrganizationId { get; set; }
    }

    public record class UpdateBoardDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public BoardVisibility? Visibility { get; set; }
        public long? OrganizationId { get; set; }
    }

    public record class GetBoardDTO : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public BoardVisibility Visibility { get; set; }
        public long BoardConfigId { get; set; }
        public long? OrganizationId { get; set; }
    }

    public record class AddBoardMemberDTO
    {
        public long BoardId { get; set; }
        public long UserId { get; set; }
        public BoardMemberRole Role { get; set; } = BoardMemberRole.Member;
    }

    public record class GetBoardMemberDTO : BaseDTO
    {
        public long BoardId { get; set; }
        public long UserId { get; set; }
        public BoardMemberRole Role { get; set; }
    }
}
