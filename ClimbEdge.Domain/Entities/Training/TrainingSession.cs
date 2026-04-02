using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums.Training;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Training
{
    public sealed class TrainingSession : BaseModel
    {
        public long TrainingWeekId { get; set; }
        public TrainingWeek? TrainingWeek { get; set; }
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
        public bool IsCompleted { get; set; } = false;
        public string? Location { get; set; }
        public long? UserSessionId { get; set; }
        public IEnumerable<SessionExercise>? Exercises { get; set; }
        public IEnumerable<TrainingSessionClimbing>? ClimbingSessions { get; set; }
        public override void InitializeSlug() => Slug = $"{TrainingWeekId}-{Date:yyyyMMdd}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<TrainingSession>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<TrainingSession>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<TrainingSession>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<TrainingSession>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<TrainingSession>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
