using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Mountains.Itinerary.Logistics
{
    public sealed class Meal : BaseModel
    {
        public long ExpeditionId { get; set; }
        public Expedition? Expedition { get; set; }
        public long? ItineraryDayId { get; set; }
        public ItineraryDay? ItineraryDay { get; set; }
        public string MealType { get; set; } = string.Empty;
        public TimeOnly? Time { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public int? Calories { get; set; }
        public bool IsVegetarian { get; set; } = false;
        public bool IsVegan { get; set; } = false;
        public string? Allergens { get; set; }
        public string? PreparedBy { get; set; }
        public decimal? Cost { get; set; }
        public string? Currency { get; set; }
        public string? Notes { get; set; }
        public override void InitializeSlug() => Slug = $"{MealType}-{ExpeditionId}-{ItineraryDayId}";
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<Meal>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<Meal>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<Meal>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<Meal>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<Meal>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
