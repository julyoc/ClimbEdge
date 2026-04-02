using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums.Training;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Training
{
    public sealed class TrainingPeriod : BaseModel
    {
        public long TrainingPlanId { get; set; }
        public TrainingPlan? TrainingPlan { get; set; }
        public TrainingPeriodType PeriodType { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WeekNumber { get; set; }
        public decimal? VolumePercentage { get; set; }
        public bool IsCompleted { get; set; } = false;
        public string? Notes { get; set; }
        public IEnumerable<TrainingWeek>? Weeks { get; set; }
        public override void InitializeSlug() => Slug = $"{Name}-{TrainingPlanId}-{WeekNumber}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<TrainingPeriod>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<TrainingPeriod>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<TrainingPeriod>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<TrainingPeriod>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<TrainingPeriod>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
