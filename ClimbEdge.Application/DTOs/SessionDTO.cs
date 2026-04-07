using ClimbEdge.Domain.Enums.Mountains.Itinerary;
using ClimbEdge.Domain.Enums.Sessions;

namespace ClimbEdge.Application.DTOs
{
    public record class StartSessionDTO
    {
        public long UserId { get; set; }
        public long? BoardId { get; set; }
        public long? ClimbZoneId { get; set; }
        public long? MountainRouteId { get; set; }
        public string? Notes { get; set; }
    }

    public record class GetSessionDTO : BaseDTO
    {
        public long UserId { get; set; }
        public long? BoardId { get; set; }
        public long? ClimbZoneId { get; set; }
        public long? MountainRouteId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public string? Notes { get; set; }
        public bool IsActive => EndedAt == null;
    }

    public record class RecordProgressDTO
    {
        public long UserSessionId { get; set; }
        public long? ClimbRouteId { get; set; }
        public long? BoardProblemId { get; set; }
        public long? BoardAngleId { get; set; }
        public long? FootRuleId { get; set; }
        public long? MountainRouteId { get; set; }
        public ClimbTickType? ClimbTickType { get; set; }
        public MountaineerTickType? MountaineerTickType { get; set; }
        public bool IsCompleted { get; set; } = false;
        public int? Duration { get; set; }
        public DateTime? TryAt { get; set; }
        public int? MaxElevationReached { get; set; }
        public string? WeatherConditions { get; set; }
    }

    public record class GetProgressDTO : BaseDTO
    {
        public long UserSessionId { get; set; }
        public long? ClimbRouteId { get; set; }
        public long? BoardProblemId { get; set; }
        public long? BoardAngleId { get; set; }
        public long? FootRuleId { get; set; }
        public long? MountainRouteId { get; set; }
        public ClimbTickType? ClimbTickType { get; set; }
        public MountaineerTickType? MountaineerTickType { get; set; }
        public bool IsCompleted { get; set; }
        public int? Duration { get; set; }
        public DateTime? TryAt { get; set; }
        public int? MaxElevationReached { get; set; }
        public string? WeatherConditions { get; set; }
    }

    public record class GetBoardSessionSummaryDTO : BaseDTO
    {
        public long BoardId { get; set; }
        public long UserId { get; set; }
        public int TotalSessions { get; set; }
        public int TotalProblemsCompleted { get; set; }
        public int TotalAttempts { get; set; }
        public int? AttemptNumber { get; set; }
        public int? SentOnAttempt { get; set; }
    }
}
