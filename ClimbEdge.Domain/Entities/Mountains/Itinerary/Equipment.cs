using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Mountains.Itinerary
{
    public sealed class Equipment : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public long EquipmentCategoryId { get; set; }
        public EquipmentCategory? EquipmentCategory { get; set; }
        public string? Description { get; set; }
        public bool IsPersonal { get; set; } = true;
        public bool IsMandatory { get; set; } = false;
        public decimal? Weight { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Specifications { get; set; }
        public string? ImageUrl { get; set; }
        public override void InitializeSlug() => Slug = $"{Name}-{EquipmentCategoryId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<Equipment>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<Equipment>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<Equipment>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<Equipment>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<Equipment>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
