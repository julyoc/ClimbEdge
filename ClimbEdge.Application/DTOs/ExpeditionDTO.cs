using ClimbEdge.Domain.Enums.Mountains.Itinerary;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;

namespace ClimbEdge.Application.DTOs
{
    public record class CreateExpeditionDTO
    {
        public long MountainId { get; set; }
        public long? MountainRouteId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int PlannedDurationDays { get; set; }
        public int MinParticipants { get; set; }
        public int MaxParticipants { get; set; }
        public string? RequiredExperienceLevel { get; set; }
        public decimal? Cost { get; set; }
        public string? Currency { get; set; }
        public bool RequiresPermit { get; set; } = false;
        public bool InsuranceRequired { get; set; } = false;
        public long OrganizedBy { get; set; }
        public long? OrganizedByOrganizationId { get; set; }
        public bool IsPublic { get; set; } = false;
        public DateTime? RegistrationDeadline { get; set; }
    }

    public record class UpdateExpeditionDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ExpeditionStatus? Status { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public int? ActualDurationDays { get; set; }
        public decimal? Cost { get; set; }
        public bool? IsPublic { get; set; }
        public DateTime? RegistrationDeadline { get; set; }
    }

    public record class GetExpeditionDTO : BaseDTO
    {
        public long MountainId { get; set; }
        public long? MountainRouteId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ExpeditionStatus Status { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int PlannedDurationDays { get; set; }
        public int? ActualDurationDays { get; set; }
        public int MinParticipants { get; set; }
        public int MaxParticipants { get; set; }
        public decimal? Cost { get; set; }
        public string? Currency { get; set; }
        public bool IsPublic { get; set; }
        public long OrganizedBy { get; set; }
    }

    public record class AddExpeditionParticipantDTO
    {
        public long ExpeditionId { get; set; }
        public long UserId { get; set; }
        public ParticipantRole Role { get; set; } = ParticipantRole.Participant;
        public string? EmergencyContact { get; set; }
        public string? SpecialRequirements { get; set; }
    }

    public record class GetExpeditionParticipantDTO : BaseDTO
    {
        public long ExpeditionId { get; set; }
        public long UserId { get; set; }
        public ParticipantRole Role { get; set; }
        public ParticipantStatus Status { get; set; }
        public DateTime InvitedAt { get; set; }
        public DateTime? JoinedAt { get; set; }
        public bool MedicalClearance { get; set; }
        public string? EmergencyContact { get; set; }
        public string? SpecialRequirements { get; set; }
    }

    // ── Equipment ──────────────────────────────────────────────────────────────

    public record class AddExpeditionEquipmentDTO
    {
        public long ExpeditionId { get; set; }
        public long EquipmentId { get; set; }
        public int Quantity { get; set; } = 1;
        public bool IsMandatory { get; set; } = false;
        public bool IsProvided { get; set; } = false;
        public long? ResponsibleParticipant { get; set; }
        public string? Notes { get; set; }
    }

    public record class GetExpeditionEquipmentDTO : BaseDTO
    {
        public long ExpeditionId { get; set; }
        public long EquipmentId { get; set; }
        public string EquipmentName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsProvided { get; set; }
        public long? ResponsibleParticipant { get; set; }
        public string? Notes { get; set; }
    }

    // ── Itinerary Track (GPS) ──────────────────────────────────────────────────

    public record class CreateItineraryTrackDTO
    {
        public long? ExpeditionId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TrackType TrackType { get; set; }
        public int StartDayNumber { get; set; }
        public int EndDayNumber { get; set; }
        public DateTime StartDate { get; set; }
        public decimal? PlannedDistance { get; set; }
        public int? PlannedDuration { get; set; }
        public long RecordedBy { get; set; }
        public string? GpsDevice { get; set; }
        /// <summary>WKT string (LINESTRING Z) for the planned route. Optional.</summary>
        public string? PlannedRouteWkt { get; set; }
    }

    public record class CompleteItineraryTrackDTO
    {
        public long TrackId { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? ActualDistance { get; set; }
        public int? ActualDuration { get; set; }
        public int? MinElevation { get; set; }
        public int? MaxElevation { get; set; }
        public int? CumulativeElevationGain { get; set; }
        public int? CumulativeElevationLoss { get; set; }
        public decimal? CompletionPercentage { get; set; }
        public decimal? RouteDeviation { get; set; }
        public string? WeatherSummary { get; set; }
        public string? DifficultySummary { get; set; }
        public string? Notes { get; set; }
        /// <summary>WKT string (LINESTRING Z) of the actual GPS route recorded.</summary>
        public string? ActualRouteWkt { get; set; }
    }

    public record class GetItineraryTrackDTO : BaseDTO
    {
        public long? ExpeditionId { get; set; }
        public string Name { get; set; } = string.Empty;
        public TrackType TrackType { get; set; }
        public int StartDayNumber { get; set; }
        public int EndDayNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? PlannedDistance { get; set; }
        public decimal? ActualDistance { get; set; }
        public int? PlannedDuration { get; set; }
        public int? ActualDuration { get; set; }
        public int? MinElevation { get; set; }
        public int? MaxElevation { get; set; }
        public decimal? CompletionPercentage { get; set; }
        public string? WeatherSummary { get; set; }
        public bool IsOfficial { get; set; }
    }

    // ── Expedition Log (daily progress) ────────────────────────────────────────

    public record class RecordExpeditionLogDTO
    {
        public long? ExpeditionId { get; set; }
        public long? UserId { get; set; }
        public long? GuideId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Duration { get; set; }
        public int? MaxElevationReached { get; set; }
        public int? MinElevationReached { get; set; }
        public string? WeatherConditions { get; set; }
        public string? WeatherAtSummit { get; set; }
        public string[]? Notes { get; set; }
        public string[]? ChallengesFaced { get; set; }
        public string[]? EquipmentUsed { get; set; }
        public bool IsSuccessful { get; set; } = true;
        public MountaineerTickType TickType { get; set; }
        public int? GroupSize { get; set; }
        public long? MountainRouteId { get; set; }
        /// <summary>WKT string (LINESTRING Z) of the actual route taken.</summary>
        public string? RouteTakenWkt { get; set; }
    }

    public record class GetExpeditionLogDTO : BaseDTO
    {
        public long? ExpeditionId { get; set; }
        public long? UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Duration { get; set; }
        public int? MaxElevationReached { get; set; }
        public int? MinElevationReached { get; set; }
        public string? WeatherConditions { get; set; }
        public bool IsSuccessful { get; set; }
        public MountaineerTickType TickType { get; set; }
        public int? GroupSize { get; set; }
        public long? MountainRouteId { get; set; }
    }

    // ── Expedition lifecycle ────────────────────────────────────────────────────

    public record class ActivateExpeditionDTO
    {
        public Guid ExpeditionUid { get; set; }
        /// <summary>Optional note stored in BaseCampInfo["activationNote"].</summary>
        public string? ActivationNote { get; set; }
    }

    public record class CloseExpeditionDTO
    {
        public Guid ExpeditionUid { get; set; }
        public ExpeditionStatus FinalStatus { get; set; }
        public int? ActualDurationDays { get; set; }
        public string? FinalNotes { get; set; }
    }

    // ── Summit attempt ─────────────────────────────────────────────────────────

    public record class RecordSummitAttemptDTO
    {
        public long ExpeditionId { get; set; }
        public long UserId { get; set; }
        public long? GuideId { get; set; }
        /// <summary>Name of the attempt, e.g. "Summit push Day 12".</summary>
        public string Name { get; set; } = string.Empty;
        public DateTime AttemptDate { get; set; }
        public DateTime? EndDate { get; set; }
        /// <summary>Highest point reached in metres.</summary>
        public int MaxElevationReached { get; set; }
        public MountaineerTickType Result { get; set; }
        public string? WeatherAtSummit { get; set; }
        public string? WeatherConditions { get; set; }
        public string[]? ChallengesFaced { get; set; }
        public string[]? EquipmentUsed { get; set; }
        public string? Notes { get; set; }
        public int? GroupSize { get; set; }
        public long? MountainRouteId { get; set; }
        public string? RouteTakenWkt { get; set; }
    }

    public record class GetSummitAttemptDTO : BaseDTO
    {
        public long ExpeditionId { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime AttemptDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MaxElevationReached { get; set; }
        public MountaineerTickType Result { get; set; }
        public string? WeatherAtSummit { get; set; }
        public int? GroupSize { get; set; }
    }

    // ── Safety incident ────────────────────────────────────────────────────────

    public record class RegisterExpeditionIncidentDTO
    {
        public long ExpeditionId { get; set; }
        public long UserId { get; set; }
        /// <summary>Short title, e.g. "Rockfall near Camp 3".</summary>
        public string Title { get; set; } = string.Empty;
        public DateTime IncidentDate { get; set; }
        public string Description { get; set; } = string.Empty;
        /// <summary>Low / Medium / High / Critical</summary>
        public string Severity { get; set; } = "Medium";
        public string? ActionTaken { get; set; }
        public string[]? PersonsInvolved { get; set; }
        public int? ElevationAtIncident { get; set; }
        public string? WeatherConditions { get; set; }
    }

    public record class GetExpeditionIncidentDTO : BaseDTO
    {
        public long ExpeditionId { get; set; }
        public long UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime IncidentDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Severity { get; set; } = string.Empty;
        public string? ActionTaken { get; set; }
        public int? ElevationAtIncident { get; set; }
    }

    // ── Critical decision ──────────────────────────────────────────────────────

    public record class RegisterCriticalDecisionDTO
    {
        public long ExpeditionId { get; set; }
        public long UserId { get; set; }
        /// <summary>e.g. "Turn-around decision Camp 4".</summary>
        public string Title { get; set; } = string.Empty;
        public DateTime DecisionDate { get; set; }
        /// <summary>e.g. GoAhead / TurnAround / RouteChange / Retreat / Evacuate</summary>
        public string DecisionType { get; set; } = string.Empty;
        public string Rationale { get; set; } = string.Empty;
        public string? Context { get; set; }
        public int? ElevationAtDecision { get; set; }
        public string? WeatherConditions { get; set; }
    }

    public record class GetCriticalDecisionDTO : BaseDTO
    {
        public long ExpeditionId { get; set; }
        public long UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime DecisionDate { get; set; }
        public string DecisionType { get; set; } = string.Empty;
        public string Rationale { get; set; } = string.Empty;
        public int? ElevationAtDecision { get; set; }
    }

    // ── Post-expedition debrief ────────────────────────────────────────────────

    public record class WriteExpeditionDebriefDTO
    {
        public long ExpeditionId { get; set; }
        public long UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string LessonsLearned { get; set; } = string.Empty;
        public string? TechnicalAssessment { get; set; }
        public string? TeamDynamics { get; set; }
        public string? EquipmentNotes { get; set; }
        public string? RecommendationsForFutureTeams { get; set; }
        public string? PersonalReflection { get; set; }
    }

    public record class GetExpeditionDebriefDTO : BaseDTO
    {
        public long ExpeditionId { get; set; }
        public long UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string LessonsLearned { get; set; } = string.Empty;
        public string? TechnicalAssessment { get; set; }
        public string? TeamDynamics { get; set; }
        public string? EquipmentNotes { get; set; }
        public string? RecommendationsForFutureTeams { get; set; }
    }

    // ── Performance summary ────────────────────────────────────────────────────

    public record class GetExpeditionPerformanceSummaryDTO
    {
        public long ExpeditionId { get; set; }
        public string ExpeditionName { get; set; } = string.Empty;
        public ExpeditionStatus Status { get; set; }
        public int TotalLogs { get; set; }
        public int SummitAttempts { get; set; }
        public int SuccessfulSummits { get; set; }
        public int TotalIncidents { get; set; }
        public int TotalDecisions { get; set; }
        public int? MaxElevationReached { get; set; }
        public int? TotalParticipants { get; set; }
        public bool HasDebrief { get; set; }
    }

    // ── Expedition Budget ──────────────────────────────────────────────────────

    public record class CreateExpeditionBudgetDTO
    {
        public long ExpeditionId { get; set; }
        public long ExpeditionBudgetCategoryId { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal PlannedCost { get; set; }
        public string Currency { get; set; } = "USD";
        public string? Vendor { get; set; }
        public string? Notes { get; set; }
    }

    public record class GetExpeditionBudgetDTO : BaseDTO
    {
        public long ExpeditionId { get; set; }
        public long ExpeditionBudgetCategoryId { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal PlannedCost { get; set; }
        public decimal? ActualCost { get; set; }
        public string Currency { get; set; } = "USD";
        public bool IsPaid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? Vendor { get; set; }
        public string? Notes { get; set; }
    }

    // ── Itinerary Day ──────────────────────────────────────────────────────────

    public record class CreateItineraryDayDTO
    {
        public long ExpeditionId { get; set; }
        public int DayNumber { get; set; }
        public DateOnly Date { get; set; }
        public DayActivityType ActivityType { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? StartElevation { get; set; }
        public int? EndElevation { get; set; }
        public float? Distance { get; set; }
        public int? ElevationGain { get; set; }
        public int? ElevationLoss { get; set; }
        public int? EstimatedDuration { get; set; }
        public int DifficultyRating { get; set; } = 5;
        public bool WeatherDependency { get; set; } = false;
        public string[]? Notes { get; set; }
    }

    public record class GetItineraryDayDTO : BaseDTO
    {
        public long ExpeditionId { get; set; }
        public int DayNumber { get; set; }
        public DateOnly Date { get; set; }
        public DayActivityType ActivityType { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? StartElevation { get; set; }
        public int? EndElevation { get; set; }
        public float? Distance { get; set; }
        public int? ElevationGain { get; set; }
        public int DifficultyRating { get; set; }
        public bool WeatherDependency { get; set; }
        public bool IsRestDay { get; set; }
    }

    // ── SafetyPlan ─────────────────────────────────────────────────────────────

    public record class CreateSafetyPlanDTO
    {
        public long ExpeditionId { get; set; }
        public string EmergencyContactName { get; set; } = string.Empty;
        public string EmergencyContactPhone { get; set; } = string.Empty;
        public string EmergencyContactRelation { get; set; } = string.Empty;
        public string? LocalRescueService { get; set; }
        public string? NearestHospital { get; set; }
        public string? EvacuationPlan { get; set; }
        public string? CommunicationPlan { get; set; }
        public string? RiskAssessment { get; set; }
        public string? ContingencyPlans { get; set; }
        public string? MedicalSupplies { get; set; }
    }

    public record class UpdateSafetyPlanDTO
    {
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public string? EmergencyContactRelation { get; set; }
        public string? LocalRescueService { get; set; }
        public string? NearestHospital { get; set; }
        public string? EvacuationPlan { get; set; }
        public string? CommunicationPlan { get; set; }
        public string? RiskAssessment { get; set; }
        public string? ContingencyPlans { get; set; }
        public string? MedicalSupplies { get; set; }
    }

    public record class GetSafetyPlanDTO : BaseDTO
    {
        public long ExpeditionId { get; set; }
        public string EmergencyContactName { get; set; } = string.Empty;
        public string EmergencyContactPhone { get; set; } = string.Empty;
        public string EmergencyContactRelation { get; set; } = string.Empty;
        public string? LocalRescueService { get; set; }
        public string? NearestHospital { get; set; }
        public string? EvacuationPlan { get; set; }
        public string? CommunicationPlan { get; set; }
        public string? RiskAssessment { get; set; }
        public string? ContingencyPlans { get; set; }
        public string? MedicalSupplies { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    // ── ItineraryDayTrack ──────────────────────────────────────────────────────

    public record class CreateItineraryDayTrackDTO
    {
        public long ItineraryDayId { get; set; }
        public long? ItineraryTrackId { get; set; }
        public long? ParticipantId { get; set; }
        public string? Name { get; set; }
        /// <summary>WKT string (LINESTRING Z) of the GPS track data.</summary>
        public string TrackDataWkt { get; set; } = string.Empty;
        /// <summary>WKT string (LINESTRING Z) of the planned route. Optional.</summary>
        public string? PlannedRouteWkt { get; set; }
        public decimal TotalDistance { get; set; }
        public int MovingTime { get; set; }
        public int TotalTime { get; set; }
        public int MinElevation { get; set; }
        public int MaxElevation { get; set; }
        public int ElevationGain { get; set; }
        public int ElevationLoss { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? RecordedBy { get; set; }
        public string? GpsDevice { get; set; }
        public decimal? Accuracy { get; set; }
        public string? WeatherConditions { get; set; }
        public string? Notes { get; set; }
        public bool IsOfficial { get; set; } = false;
    }

    public record class GetItineraryDayTrackDTO : BaseDTO
    {
        public long ItineraryDayId { get; set; }
        public long? ItineraryTrackId { get; set; }
        public long? ParticipantId { get; set; }
        public string? Name { get; set; }
        public decimal TotalDistance { get; set; }
        public int MovingTime { get; set; }
        public int TotalTime { get; set; }
        public int MinElevation { get; set; }
        public int MaxElevation { get; set; }
        public int ElevationGain { get; set; }
        public int ElevationLoss { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? RecordedBy { get; set; }
        public string? GpsDevice { get; set; }
        public string? WeatherConditions { get; set; }
        public string? Notes { get; set; }
        public bool IsOfficial { get; set; }
    }

    // ── ItineraryDayWaypoint ───────────────────────────────────────────────────

    public record class CreateItineraryDayWaypointDTO
    {
        public long ItineraryDayId { get; set; }
        public long? ItineraryDayTrackId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        /// <summary>WKT string (POINT Z) of the waypoint location.</summary>
        public string LocationWkt { get; set; } = string.Empty;
        public int Elevation { get; set; }
        public DateTime Timestamp { get; set; }
        public long WaypointTypeId { get; set; }
        public int? Duration { get; set; }
        public string? Photo { get; set; }
        public string? Notes { get; set; }
        public long? RecordedBy { get; set; }
        public string? WeatherConditions { get; set; }
        public decimal? Temperature { get; set; }
        public bool IsPlanned { get; set; } = false;
        public bool IsEmergency { get; set; } = false;
    }

    public record class GetItineraryDayWaypointDTO : BaseDTO
    {
        public long ItineraryDayId { get; set; }
        public long? ItineraryDayTrackId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Elevation { get; set; }
        public DateTime Timestamp { get; set; }
        public long WaypointTypeId { get; set; }
        public int? Duration { get; set; }
        public string? Photo { get; set; }
        public string? Notes { get; set; }
        public long? RecordedBy { get; set; }
        public string? WeatherConditions { get; set; }
        public decimal? Temperature { get; set; }
        public bool IsPlanned { get; set; }
        public bool IsEmergency { get; set; }
    }

    // ── Equipment catalog ──────────────────────────────────────────────────────

    public record class CreateEquipmentDTO
    {
        public string Name { get; set; } = string.Empty;
        public long EquipmentCategoryId { get; set; }
        public string? Description { get; set; }
        public bool IsPersonal { get; set; } = true;
        public bool IsMandatory { get; set; } = false;
        public decimal? Weight { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Specifications { get; set; }
        public string? ImageUrl { get; set; }
    }

    public record class GetEquipmentDTO : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public long EquipmentCategoryId { get; set; }
        public string? Description { get; set; }
        public bool IsPersonal { get; set; }
        public bool IsMandatory { get; set; }
        public decimal? Weight { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Specifications { get; set; }
        public string? ImageUrl { get; set; }
    }
}
