using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Training
{
    public sealed class TrainingGoal : BaseModel
    {
        public long UserId { get; set; }
        public long? TrainingPlanId { get; set; }
        public TrainingPlan? TrainingPlan { get; set; }
        public string GoalType { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? TargetDate { get; set; }
        public decimal? TargetValue { get; set; }
        public string? TargetUnit { get; set; }
        public decimal? CurrentValue { get; set; }
        public bool IsAchieved { get; set; } = false;
        public DateTime? AchievedDate { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; } = true;
        public override void InitializeSlug() => Slug = $"{UserId}-{Title.ToLower().Replace(" ", "-")}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<TrainingGoal>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<TrainingGoal>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<TrainingGoal>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<TrainingGoal>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<TrainingGoal>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
