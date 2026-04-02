using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Training
{
    public sealed class PhysiologicalData : BaseModel
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
        public string? Notes { get; set; }
        public string? MeasuredBy { get; set; }
        public override void InitializeSlug() => Slug = $"physio-{UserId}-{MeasurementDate:yyyyMMdd}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<PhysiologicalData>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<PhysiologicalData>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<PhysiologicalData>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<PhysiologicalData>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<PhysiologicalData>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
