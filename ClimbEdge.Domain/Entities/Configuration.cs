using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Entities.Auditing;
using ClimbEdge.Domain.Enums;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities
{
    public sealed class Configuration : BaseModel
    {
        public ConfigurationKey Key { get; set; }
        public long UserId { get; set; }
        public string Value { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsSensitive { get; set; } = false;
        public Configuration() : base() { }
        public override void InitializeSlug()
        {
            Slug = $"{UserId}/{Key}";
            AddDomainEvent(new EntityDomainEvent<Configuration>(Slug, EntityDomainEventType.Created));
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<Configuration>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<Configuration>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<Configuration>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<Configuration>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<Configuration>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
    }
}
