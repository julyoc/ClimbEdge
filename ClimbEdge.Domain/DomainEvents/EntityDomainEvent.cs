using ClimbEdge.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.DomainEvents
{
    public enum EntityDomainEventType
    {
        Created,
        Updated,
        Deleted,
        Restored,
        Locked
    }
    public class EntityDomainEvent<T> : IDomainEvent
    {
        public string Slug { get; set; }
        public string EntityName { get; set; }
        public DateTime OccurredOn => DateTime.UtcNow;
        public EntityDomainEventType EventType { get; set; }
        public Dictionary<string, object> State { get; set; } = new Dictionary<string, object>();
        public EntityDomainEvent(string slug, EntityDomainEventType eventType)
        {
            Slug = slug;
            EntityName = typeof(T).Name;
            EventType = eventType;
        }
        public EntityDomainEvent(string slug, EntityDomainEventType eventType, Dictionary<string, object> state)
        {
            Slug = slug;
            EntityName = typeof(T).Name;
            EventType = eventType;
            State = state ?? new Dictionary<string, object>();
        }
    }
}
