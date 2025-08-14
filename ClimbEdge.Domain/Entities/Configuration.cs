using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities
{
    public class Configuration : BaseModel
    {
        public ConfigurationKey Key { get; set; }
        public long UserId { get; set; }
        public string Value { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsSensitive { get; set; } = false;
        public Configuration() : base() { }
        public override void InitializeSlug()
        {
            Slug = $"{UserId}";
            AddDomainEvent(new EntityDomainEvent<Configuration>(Slug, EntityDomainEventType.Created));
        }
    }
}
