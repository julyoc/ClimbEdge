using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Mountains.Itinerary
{
    public sealed class SafetyPlan : BaseModel
    {
        public long ExpeditionId { get; set; }
        public Expedition? Expedition { get; set; }
        public string EmergencyContactName { get; set; } = string.Empty;
        public string EmergencyContactPhone { get; set; } = string.Empty;
        public string EmergencyContactRelation { get; set; } = string.Empty;
        public string? LocalRescueService { get; set; }
        public string? NearestHospital { get; set; }
        public string? EvacuationPlan { get; set; }
        public string? CommunicationPlan { get; set; }
        public string? RiskAssessment { get; set; }
        public string? ContingencyPlans { get; set; }
        public string? MedicalSupplies { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public override void InitializeSlug() => Slug = $"safetyplan-{ExpeditionId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<SafetyPlan>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<SafetyPlan>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<SafetyPlan>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<SafetyPlan>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<SafetyPlan>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
