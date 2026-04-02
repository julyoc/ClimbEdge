using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Training
{
    public sealed class TrainingPlan : BaseModel
    {
        public long UserId { get; set; }
        public UserProfile? User { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public string[]? LongTermGoal { get; set; }
        public string[]? ShortTermGoal { get; set; }
        public long? BaselinePhysiologicalDataId { get; set; }
        public PhysiologicalData? BaselinePhysiologicalData { get; set; }
        public long? CreatedByUserId { get; set; }
        public string? Notes { get; set; }
        public IEnumerable<TrainingPeriod>? Periods { get; set; }
        public IEnumerable<TrainingGoal>? Goals { get; set; }
        public IEnumerable<TrainingProgress>? Progress { get; set; }
        public override void InitializeSlug() => Slug = $"{Name}-{UserId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<TrainingPlan>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<TrainingPlan>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<TrainingPlan>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<TrainingPlan>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<TrainingPlan>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
