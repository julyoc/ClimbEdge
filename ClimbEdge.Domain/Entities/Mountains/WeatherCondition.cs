using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Mountains
{
    public sealed class WeatherCondition : BaseModel
    {
        public long MountainId { get; set; }
        public Mountain? Mountain { get; set; }
        public DateTime RecordedAt { get; set; }
        public float? Temperature { get; set; }
        public float? WindSpeed { get; set; }
        public float? WindDirection { get; set; }
        public float? Humidity { get; set; }
        public float? Pressure { get; set; }
        public float? Visibility { get; set; }
        public string? Condition {  get; set; }
        public float? SnowDepth { get; set; }
        public string? DataSource {  get; set; }
        public float? RainFall {  get; set; }
        public float? SnowFall { get; set; }
        public override void InitializeSlug()
        {
            Slug = $"{MountainId}-{RecordedAt.Ticks}";
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<WeatherCondition>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<WeatherCondition>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<WeatherCondition>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<WeatherCondition>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<WeatherCondition>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
    }
}
