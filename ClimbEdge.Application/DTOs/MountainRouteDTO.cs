using ClimbEdge.Domain.Enums.Mountains;

namespace ClimbEdge.Application.DTOs
{
    public record class CreateMountainRouteDTO
    {
        public long MountainId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public RouteType Type { get; set; }
        public long DifficultyScaleId { get; set; }
        public float Distance { get; set; }
        public int? ElevationGain { get; set; }
        public int? ElevationLoss { get; set; }
        public int EstimatedDuration { get; set; }
        public SeasonType BestSeason { get; set; }
        public bool RequiresPermit { get; set; } = false;
        public int? MaxParticipants { get; set; }
        public bool IsGuided { get; set; } = false;
        public int DangerLevel { get; set; } = 5;
        public DateOnly? FirstAscentDate { get; set; }
        public string? FirstAscentBy { get; set; }
    }

    public record class UpdateMountainRouteDTO
    {
        public string? Description { get; set; }
        public float? Distance { get; set; }
        public int? ElevationGain { get; set; }
        public int? EstimatedDuration { get; set; }
        public SeasonType? BestSeason { get; set; }
        public bool? RequiresPermit { get; set; }
        public int? MaxParticipants { get; set; }
        public bool? IsGuided { get; set; }
        public int? DangerLevel { get; set; }
    }

    public record class GetMountainRouteDTO : BaseDTO
    {
        public long MountainId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public RouteType Type { get; set; }
        public long DifficultyScaleId { get; set; }
        public float Distance { get; set; }
        public int? ElevationGain { get; set; }
        public int? ElevationLoss { get; set; }
        public int EstimatedDuration { get; set; }
        public SeasonType BestSeason { get; set; }
        public bool RequiresPermit { get; set; }
        public int? MaxParticipants { get; set; }
        public bool IsGuided { get; set; }
        public int DangerLevel { get; set; }
        public DateOnly? FirstAscentDate { get; set; }
        public string? FirstAscentBy { get; set; }
    }
}
