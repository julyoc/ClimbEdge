using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Entities.DifficultyScales;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities
{
    public sealed class UserExperienceLevelScale : BaseModel
    {
        public long UserId { get; set; }
        public UserProfile? User { get; set; }
        public long DifficultyScaleId { get; set; }
        public DifficultyScale? DifficultyScale { get; set; }
        public string? Description { get; set; }
        public override void InitializeSlug()
        {
            Slug = $"{UserId}-{DifficultyScaleId}";
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<UserExperienceLevelScale>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<UserExperienceLevelScale>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<UserExperienceLevelScale>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<UserExperienceLevelScale>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<UserExperienceLevelScale>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
    }
}
