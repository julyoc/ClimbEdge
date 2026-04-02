using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums.Training;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Training
{
    public sealed class FitnessTest : BaseModel
    {
        public long UserId { get; set; }
        public DateTime TestDate { get; set; }
        public int? Test300mTime { get; set; }
        public FitnessTestLevel? Test300mLevel { get; set; }
        public int? ParallelDips60s { get; set; }
        public FitnessTestLevel? ParallelDips60sLevel { get; set; }
        public int? Crunches60s { get; set; }
        public FitnessTestLevel? Crunches60sLevel { get; set; }
        public int? Squats60s { get; set; }
        public FitnessTestLevel? Squats60sLevel { get; set; }
        public int? PullUps60s { get; set; }
        public FitnessTestLevel? PullUps60sLevel { get; set; }
        public int? BoxJumps60s { get; set; }
        public FitnessTestLevel? BoxJumps60sLevel { get; set; }
        public int? PushUps60s { get; set; }
        public FitnessTestLevel? PushUps60sLevel { get; set; }
        public FitnessTestLevel? OverallLevel { get; set; }
        public decimal? TotalScore { get; set; }
        public string? Notes { get; set; }
        public override void InitializeSlug() => Slug = $"fitnesstest-{UserId}-{TestDate:yyyyMMdd}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<FitnessTest>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<FitnessTest>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<FitnessTest>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<FitnessTest>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<FitnessTest>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
