namespace ClimbEdge.Application.DTOs
{
    public record class GetDifficultyScaleDTO : BaseDTO
    {
        public long DifficultyScaleNameId { get; set; }
        public string DifficultyScaleName { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public int IRCRA { get; set; }
        public long? DifficultyGroupId { get; set; }
        public string? Description { get; set; }
    }
}
