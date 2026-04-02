using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Training
{
    public sealed class TrainingWeek : BaseModel
    {
        public long TrainingPeriodId { get; set; }
        public TrainingPeriod? TrainingPeriod { get; set; }
        public int WeekNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? TrainingObjective { get; set; }
        public string? ClimbingObjective { get; set; }
        public string? NutritionObjective { get; set; }
        public decimal PlannedHours { get; set; }
        public decimal? CompletedHours { get; set; }
        public decimal? Zone1Hours { get; set; }
        public decimal? Zone2Hours { get; set; }
        public decimal? Zone3Hours { get; set; }
        public decimal? StrengthHours { get; set; }
        public decimal? AlpineClimbingHours { get; set; }
        public decimal? SchoolClimbingHours { get; set; }
        public int? ElevationGained { get; set; }
        public string? WeeklyEvaluation { get; set; }
        public bool IsCompleted { get; set; } = false;
        public IEnumerable<TrainingSession>? Sessions { get; set; }
        public TrainingVolume? TrainingVolume { get; set; }
        public override void InitializeSlug() => Slug = $"{TrainingPeriodId}-week{WeekNumber}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<TrainingWeek>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<TrainingWeek>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<TrainingWeek>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<TrainingWeek>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<TrainingWeek>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
