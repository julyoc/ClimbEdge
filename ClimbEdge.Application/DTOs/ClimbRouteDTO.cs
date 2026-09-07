namespace ClimbEdge.Application.DTOs
{
    public record class CreateClimbRouteDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long DifficultyScaleId { get; set; }
        public long DifficultyScaleNameId { get; set; }
        public long? ClimbTagId { get; set; }
        public int? PitchCount { get; set; }
        public DateTime? FirstAscentDate { get; set; }
        public long? ClimbZoneId { get; set; }
    }

    public record class UpdateClimbRouteDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public long? DifficultyScaleId { get; set; }
        public long? ClimbTagId { get; set; }
        public int? PitchCount { get; set; }
        public long? ClimbZoneId { get; set; }
    }

    public record class GetClimbRouteDTO : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long DifficultyScaleId { get; set; }
        public long DifficultyScaleNameId { get; set; }
        public long? ClimbTagId { get; set; }
        public int? PitchCount { get; set; }
        public DateTime? FirstAscentDate { get; set; }
        public long? ClimbZoneId { get; set; }
    }

    // ── ClimbRouteDescription ──────────────────────────────────────────────────

    public record class CreateClimbRouteDescriptionDTO
    {
        public long ClimbRouteId { get; set; }
        public string Content { get; set; } = string.Empty;
    }

    public record class GetClimbRouteDescriptionDTO : BaseDTO
    {
        public long ClimbRouteId { get; set; }
        public string Content { get; set; } = string.Empty;
    }

    // ── ClimbTag ───────────────────────────────────────────────────────────────

    public record class CreateClimbTagDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public record class GetClimbTagDTO : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    // ── RockFeatures ───────────────────────────────────────────────────────────

    public record class CreateRockFeaturesDTO
    {
        public long ClimbRouteId { get; set; }
        public string? Description { get; set; }
        public string? RockType { get; set; }
    }

    public record class GetRockFeaturesDTO : BaseDTO
    {
        public long ClimbRouteId { get; set; }
        public string? Description { get; set; }
        public string? RockType { get; set; }
    }
}
