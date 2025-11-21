using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Enums.Mountains.Itinerary;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Mountains.Itinerary
{
    public sealed class ExpeditionParticipant : BaseModel
    {
        public long ExpeditionId { get; set; }
        public Expedition? Expedition { get; set; }
        public long UserId { get; set; }
        public UserProfile? User {  get; set; }
        public ParticipantRole Role { get; set; }
        public DateTime InvitedAt { get; set; } = DateTime.Now;
        public DateTime? JoinedAt { get; set; }
        public ParticipantStatus Status { get; set; } = ParticipantStatus.Registered;
        public DateTime? StatusChangedAt { get; set; }
        public bool MedicalClearance { get; set; }
        public string? EmergencyContact { get; set; }
        public string? SpecialRequirements { get; set; }
        public string? PaymentStatus { get; set; }
        public string[]? Notes { get; set; }
        public override void InitializeSlug()
        {
            throw new NotImplementedException();
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<ExpeditionParticipant>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<ExpeditionParticipant>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<ExpeditionParticipant>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<ExpeditionParticipant>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<ExpeditionParticipant>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
    }
}
