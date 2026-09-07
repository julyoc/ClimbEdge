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

    // ── RouteTrack ─────────────────────────────────────────────────────────────

    public record class CreateRouteTrackDTO
    {
        public long MountainRouteId { get; set; }
        public string Name { get; set; } = string.Empty;
        /// <summary>WKT string (LINESTRING Z) of the GPS track data.</summary>
        public string TrackDataWkt { get; set; } = string.Empty;
        public float TotalDistance { get; set; }
        public int MinElevation { get; set; }
        public int MaxElevation { get; set; }
        public string? RecordedBy { get; set; }
        public DateTime? RecordedAt { get; set; }
        public string? GpsDevice { get; set; }
        public float? Accuracy { get; set; }
    }

    public record class GetRouteTrackDTO : BaseDTO
    {
        public long MountainRouteId { get; set; }
        public string Name { get; set; } = string.Empty;
        public float TotalDistance { get; set; }
        public int MinElevation { get; set; }
        public int MaxElevation { get; set; }
        public string? RecordedBy { get; set; }
        public DateTime? RecordedAt { get; set; }
        public string? GpsDevice { get; set; }
        public float? Accuracy { get; set; }
    }

    // ── RouteWaypoint ──────────────────────────────────────────────────────────

    public record class CreateRouteWaypointDTO
    {
        public long MountainRouteId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        /// <summary>WKT string (POINT Z) of the waypoint location.</summary>
        public string LocationWkt { get; set; } = string.Empty;
        public int Sequence { get; set; }
        public long WaypointTypeId { get; set; }
        public int EstimatedTimeFromPrevious { get; set; }
        public string? Notes { get; set; }
        public string[]? ImageUrl { get; set; }
    }

    public record class GetRouteWaypointDTO : BaseDTO
    {
        public long MountainRouteId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Sequence { get; set; }
        public long WaypointTypeId { get; set; }
        public int EstimatedTimeFromPrevious { get; set; }
        public string? Notes { get; set; }
        public string[]? ImageUrl { get; set; }
    }

    // ── WeatherCondition ───────────────────────────────────────────────────────

    public record class CreateWeatherConditionDTO
    {
        public long MountainId { get; set; }
        public DateTime RecordedAt { get; set; }
        public float? Temperature { get; set; }
        public float? WindSpeed { get; set; }
        public float? WindDirection { get; set; }
        public float? Humidity { get; set; }
        public float? Pressure { get; set; }
        public float? Visibility { get; set; }
        public string? Condition { get; set; }
        public float? SnowDepth { get; set; }
        public string? DataSource { get; set; }
        public float? RainFall { get; set; }
        public float? SnowFall { get; set; }
    }

    public record class GetWeatherConditionDTO : BaseDTO
    {
        public long MountainId { get; set; }
        public DateTime RecordedAt { get; set; }
        public float? Temperature { get; set; }
        public float? WindSpeed { get; set; }
        public float? WindDirection { get; set; }
        public float? Humidity { get; set; }
        public float? Pressure { get; set; }
        public float? Visibility { get; set; }
        public string? Condition { get; set; }
        public float? SnowDepth { get; set; }
        public string? DataSource { get; set; }
        public float? RainFall { get; set; }
        public float? SnowFall { get; set; }
    }
}
