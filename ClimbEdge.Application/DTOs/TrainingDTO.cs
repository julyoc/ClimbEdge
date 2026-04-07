using ClimbEdge.Domain.Enums.Training;

namespace ClimbEdge.Application.DTOs
{
    public record class CreateTrainingPlanDTO
    {
        public long UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string[]? LongTermGoal { get; set; }
        public string[]? ShortTermGoal { get; set; }
        public long? BaselinePhysiologicalDataId { get; set; }
        public long? CreatedByUserId { get; set; }
    }

    public record class UpdateTrainingPlanDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
        public string[]? LongTermGoal { get; set; }
        public string[]? ShortTermGoal { get; set; }
    }

    public record class GetTrainingPlanDTO : BaseDTO
    {
        public long UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public string[]? LongTermGoal { get; set; }
        public string[]? ShortTermGoal { get; set; }
    }

    public record class LogTrainingSessionDTO
    {
        public long TrainingWeekId { get; set; }
        public DateTime Date { get; set; }
        public ActivityType ActivityType { get; set; }
        public int PlannedDuration { get; set; }
        public int? ActualDuration { get; set; }
        public TrainingZone? TrainingZone { get; set; }
        public int? ElevationGained { get; set; }
        public decimal? WeightCarried { get; set; }
        public decimal? Distance { get; set; }
        public int? HeartRateAvg { get; set; }
        public int? HeartRateMax { get; set; }
        public int? Rating { get; set; }
        public string? Notes { get; set; }
        public string? Location { get; set; }
        public long? UserSessionId { get; set; }
    }

    public record class GetTrainingSessionDTO : BaseDTO
    {
        public long TrainingWeekId { get; set; }
        public DateTime Date { get; set; }
        public ActivityType ActivityType { get; set; }
        public int PlannedDuration { get; set; }
        public int? ActualDuration { get; set; }
        public TrainingZone? TrainingZone { get; set; }
        public int? ElevationGained { get; set; }
        public decimal? WeightCarried { get; set; }
        public decimal? Distance { get; set; }
        public int? HeartRateAvg { get; set; }
        public int? HeartRateMax { get; set; }
        public int? Rating { get; set; }
        public bool IsCompleted { get; set; }
        public string? Notes { get; set; }
        public string? Location { get; set; }
    }

    // ── Training Period ────────────────────────────────────────────────────────

    public record class CreateTrainingPeriodDTO
    {
        public long TrainingPlanId { get; set; }
        public TrainingPeriodType PeriodType { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WeekNumber { get; set; }
        public decimal? VolumePercentage { get; set; }
        public string? Notes { get; set; }
    }

    public record class GetTrainingPeriodDTO : BaseDTO
    {
        public long TrainingPlanId { get; set; }
        public TrainingPeriodType PeriodType { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WeekNumber { get; set; }
        public decimal? VolumePercentage { get; set; }
        public bool IsCompleted { get; set; }
    }

    // ── Training Week ──────────────────────────────────────────────────────────

    public record class CreateTrainingWeekDTO
    {
        public long TrainingPeriodId { get; set; }
        public int WeekNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? TrainingObjective { get; set; }
        public string? ClimbingObjective { get; set; }
        public string? NutritionObjective { get; set; }
        public decimal PlannedHours { get; set; }
    }

    public record class CompleteTrainingWeekDTO
    {
        public Guid TrainingWeekUid { get; set; }
        public decimal? CompletedHours { get; set; }
        public decimal? Zone1Hours { get; set; }
        public decimal? Zone2Hours { get; set; }
        public decimal? Zone3Hours { get; set; }
        public decimal? StrengthHours { get; set; }
        public decimal? AlpineClimbingHours { get; set; }
        public decimal? SchoolClimbingHours { get; set; }
        public int? ElevationGained { get; set; }
        public string? WeeklyEvaluation { get; set; }
    }

    public record class GetTrainingWeekDTO : BaseDTO
    {
        public long TrainingPeriodId { get; set; }
        public int WeekNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? TrainingObjective { get; set; }
        public string? ClimbingObjective { get; set; }
        public decimal PlannedHours { get; set; }
        public decimal? CompletedHours { get; set; }
        public bool IsCompleted { get; set; }
        public string? WeeklyEvaluation { get; set; }
    }

    // ── Create/Complete Training Session (separate from LogTrainingSessionDTO) ─

    public record class CreateTrainingSessionDTO
    {
        public long TrainingWeekId { get; set; }
        public DateTime Date { get; set; }
        public ActivityType ActivityType { get; set; }
        public int PlannedDuration { get; set; }
        public TrainingZone? TrainingZone { get; set; }
        public string? Location { get; set; }
        public string? Notes { get; set; }
    }

    public record class CompleteTrainingSessionDTO
    {
        public Guid TrainingSessionUid { get; set; }
        public int ActualDuration { get; set; }
        public TrainingZone? TrainingZone { get; set; }
        public int? ElevationGained { get; set; }
        public decimal? WeightCarried { get; set; }
        public decimal? Distance { get; set; }
        public int? HeartRateAvg { get; set; }
        public int? HeartRateMax { get; set; }
        public int? Rating { get; set; }
        public string? Notes { get; set; }
        public long? UserSessionId { get; set; }
    }

    // ── Session Exercise ───────────────────────────────────────────────────────

    public record class LogSessionExerciseDTO
    {
        public long TrainingSessionId { get; set; }
        public long TrainingExerciseId { get; set; }
        public int Sequence { get; set; }
        public int? Sets { get; set; }
        public int? Reps { get; set; }
        public decimal? Weight { get; set; }
        public int? Duration { get; set; }
        public decimal? Distance { get; set; }
        public int? RestTime { get; set; }
        public string? Notes { get; set; }
    }

    public record class GetSessionExerciseDTO : BaseDTO
    {
        public long TrainingSessionId { get; set; }
        public long TrainingExerciseId { get; set; }
        public int Sequence { get; set; }
        public int? Sets { get; set; }
        public int? Reps { get; set; }
        public decimal? Weight { get; set; }
        public int? Duration { get; set; }
        public decimal? Distance { get; set; }
        public int? RestTime { get; set; }
        public string? Notes { get; set; }
    }

    // ── Training Goal ──────────────────────────────────────────────────────────

    public record class SetTrainingGoalDTO
    {
        public long UserId { get; set; }
        public long? TrainingPlanId { get; set; }
        public string GoalType { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? TargetDate { get; set; }
        public decimal? TargetValue { get; set; }
        public string? TargetUnit { get; set; }
        public int Priority { get; set; } = 1;
    }

    public record class GetTrainingGoalDTO : BaseDTO
    {
        public long UserId { get; set; }
        public long? TrainingPlanId { get; set; }
        public string GoalType { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime? TargetDate { get; set; }
        public decimal? TargetValue { get; set; }
        public string? TargetUnit { get; set; }
        public decimal? CurrentValue { get; set; }
        public bool IsAchieved { get; set; }
        public DateTime? AchievedDate { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
    }

    // ── Training Progress ──────────────────────────────────────────────────────

    public record class RecordTrainingProgressDTO
    {
        public long UserId { get; set; }
        public long TrainingPlanId { get; set; }
        public DateTime MeasurementDate { get; set; }
        public string MetricType { get; set; } = string.Empty;
        public string MetricName { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public string? MeasuredBy { get; set; }
    }

    public record class GetTrainingProgressDTO : BaseDTO
    {
        public long UserId { get; set; }
        public long TrainingPlanId { get; set; }
        public DateTime MeasurementDate { get; set; }
        public string MetricType { get; set; } = string.Empty;
        public string MetricName { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string? Notes { get; set; }
    }

    // ── Physiological Data ─────────────────────────────────────────────────────

    public record class RecordPhysiologicalDataDTO
    {
        public long UserId { get; set; }
        public DateTime MeasurementDate { get; set; }
        public int? MaxHeartRate { get; set; }
        public int? RestingHeartRate { get; set; }
        public decimal? VO2Max { get; set; }
        public decimal? VO2MaxFraction { get; set; }
        public decimal? BodyWeight { get; set; }
        public decimal? BodyFat { get; set; }
        public decimal? MuscleComposition { get; set; }
        public string? MeasuredBy { get; set; }
        public string? Notes { get; set; }
    }

    public record class GetPhysiologicalDataDTO : BaseDTO
    {
        public long UserId { get; set; }
        public DateTime MeasurementDate { get; set; }
        public int? MaxHeartRate { get; set; }
        public int? RestingHeartRate { get; set; }
        public decimal? VO2Max { get; set; }
        public decimal? VO2MaxFraction { get; set; }
        public decimal? BodyWeight { get; set; }
        public decimal? BodyFat { get; set; }
        public decimal? MuscleComposition { get; set; }
        public string? MeasuredBy { get; set; }
    }

    // ── Fitness Test ───────────────────────────────────────────────────────────

    public record class RecordFitnessTestDTO
    {
        public long UserId { get; set; }
        public DateTime TestDate { get; set; }
        public int? Test300mTime { get; set; }
        public int? ParallelDips60s { get; set; }
        public int? Crunches60s { get; set; }
        public int? Squats60s { get; set; }
        public int? PullUps60s { get; set; }
        public int? BoxJumps60s { get; set; }
        public int? PushUps60s { get; set; }
        public string? Notes { get; set; }
    }

    public record class GetFitnessTestDTO : BaseDTO
    {
        public long UserId { get; set; }
        public DateTime TestDate { get; set; }
        public int? Test300mTime { get; set; }
        public FitnessTestLevel? Test300mLevel { get; set; }
        public int? ParallelDips60s { get; set; }
        public FitnessTestLevel? ParallelDips60sLevel { get; set; }
        public int? PullUps60s { get; set; }
        public FitnessTestLevel? PullUps60sLevel { get; set; }
        public FitnessTestLevel? OverallLevel { get; set; }
        public decimal? TotalScore { get; set; }
        public string? Notes { get; set; }
    }

    // ── Training Volume ────────────────────────────────────────────────────────

    public record class GetTrainingVolumeDTO : BaseDTO
    {
        public long TrainingWeekId { get; set; }
        public decimal Zone1Hours { get; set; }
        public decimal Zone34Hours { get; set; }
        public decimal StrengthHours { get; set; }
        public decimal WeeklyTotal { get; set; }
        public decimal AccumulatedTotal { get; set; }
        public decimal? PlannedVsActual { get; set; }
    }

    public record class GetTrainingExerciseDTO : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TrainingExerciseCategory Category { get; set; }
        public TrainingExerciseSubCategory SubCategory { get; set; }
        public string? MuscleGroups { get; set; }
        public string? Equipment { get; set; }
        public string? Instructions { get; set; }
        public string? VideoUrl { get; set; }
        public string? ImageUrl { get; set; }
        public int DifficultyLevel { get; set; }
        public decimal? EstimatedCalories { get; set; }
    }

    public record class GetTrainingTemplateDTO : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TrainingPeriodType PeriodType { get; set; }
        public int DurationWeeks { get; set; }
        public string TargetGoal { get; set; } = string.Empty;
        public decimal Zone1Percentage { get; set; }
        public decimal Zone2Percentage { get; set; }
        public decimal Zone3Percentage { get; set; }
        public decimal Zone4Percentage { get; set; }
        public decimal StrengthPercentage { get; set; }
        public bool IsPublic { get; set; }
        public long CreatedByUserId { get; set; }
        public int UsageCount { get; set; }
    }
}
