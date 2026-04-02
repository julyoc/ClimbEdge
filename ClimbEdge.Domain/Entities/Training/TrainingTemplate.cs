using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums.Training;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Training
{
    public sealed class TrainingTemplate : BaseModel
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
        public bool IsPublic { get; set; } = false;
        public long CreatedByUserId { get; set; }
        public int UsageCount { get; set; } = 0;
        public override void InitializeSlug() => Slug = Name.ToLower().Replace(" ", "-");
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<TrainingTemplate>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<TrainingTemplate>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<TrainingTemplate>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<TrainingTemplate>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<TrainingTemplate>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
