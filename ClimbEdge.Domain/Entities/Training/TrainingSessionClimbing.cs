using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Entities.Sessions;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Training
{
    public sealed class TrainingSessionClimbing : BaseModel
    {
        public long TrainingSessionId { get; set; }
        public TrainingSession? TrainingSession { get; set; }
        public long UserSessionId { get; set; }
        public UserSession? UserSession { get; set; }
        public string? PlannedObjective { get; set; }
        public string? ActualPerformance { get; set; }
        public string? TechnicalFocus { get; set; }
        public int? IntensityLevel { get; set; }
        public int? RestTimesBetweenProblems { get; set; }
        public int? WarmUpDuration { get; set; }
        public int? CoolDownDuration { get; set; }
        public string? TrainingNotes { get; set; }
        public string? CoachFeedback { get; set; }
        public override void InitializeSlug() => Slug = $"{TrainingSessionId}-{UserSessionId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<TrainingSessionClimbing>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<TrainingSessionClimbing>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<TrainingSessionClimbing>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<TrainingSessionClimbing>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<TrainingSessionClimbing>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
