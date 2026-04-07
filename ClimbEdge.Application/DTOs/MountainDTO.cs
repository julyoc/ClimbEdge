using ClimbEdge.Domain.Enums.Mountains;

namespace ClimbEdge.Application.DTOs
{
    public record class CreateMountainDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public MountainType Type { get; set; }
        public int Elevation { get; set; }
        public string Country { get; set; } = string.Empty;
        public string? Region { get; set; }
        public string? State { get; set; }
        public DateOnly? FirstAscentDate { get; set; }
        public string? FirstAscentBy { get; set; }
        public short DifficultyRating { get; set; }
        public string[]? ImageUrls { get; set; }
    }

    public record class UpdateMountainDTO
    {
        public string? Description { get; set; }
        public string? Region { get; set; }
        public string? State { get; set; }
        public bool? IsActive { get; set; }
        public short? DifficultyRating { get; set; }
        public string[]? ImageUrls { get; set; }
    }

    public record class GetMountainDTO : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public MountainType Type { get; set; }
        public int Elevation { get; set; }
        public string Country { get; set; } = string.Empty;
        public string? Region { get; set; }
        public string? State { get; set; }
        public DateOnly? FirstAscentDate { get; set; }
        public string? FirstAscentBy { get; set; }
        public bool IsActive { get; set; }
        public short DifficultyRating { get; set; }
        public string[]? ImageUrls { get; set; }
    }
}
