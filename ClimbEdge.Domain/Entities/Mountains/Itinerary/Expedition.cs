using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Entities.DifficultyScales;
using ClimbEdge.Domain.Entities.Organizations;
using ClimbEdge.Domain.Enums.Mountains.Itinerary;
using ClimbEdge.Domain.Shared;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Mountains.Itinerary
{
    public sealed class Expedition : BaseModel
    {
        public long MountainId { get; set; }
        public Mountain? Mountain { get; set; }
        public long? MountainRouteId { get; set; }
        public MountainRoute? MountainRoute { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ExpeditionStatus Status { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int PlannedDurationDays { get; set; }
        public int? ActualDurationDays { get; set; }
        public int MinParticipants {  get; set; }
        public int MaxParticipants { get; set; }
        public string? RequiredExperienceLevel { get; set; }
        public decimal? Cost { get; set; }
        public string? Currency { get; set; }
        public bool RequiresPermit { get; set; } = false;
        public string? PermitNumber { get; set; }
        public bool InsuranceRequired { get; set; } = false;
        public string[]? EmergencyContactInfo { get; set; }
        public Point? BaseCampLocation { get; set; }
        public IDictionary<string, object>? BaseCampInfo { get; set; }
        public long OrganizedBy { get; set; }
        public UserProfile? OrganizedUser {  get; set; }
        public long? OrganizedByOrganizationId { get; set; }
        public Organization? OrganizedByOrganization { get; set; }
        public bool IsPublic { get; set; } = false;
        public bool IsDraft { get; set; } = false;
        public DateTime? RegistrationDeadline { get; set; }
        public override void InitializeSlug()
        {
            Slug = $"{Name}-{MountainId}-{MountainRouteId}";
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<Expedition>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<Expedition>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<Expedition>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<Expedition>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<Expedition>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
        public IEnumerable<MountainExpeditionLog>? MountainExpeditionLogs { get; set; }
        public IEnumerable<ExpeditionLevelScales>? ExpeditionLevelScales { get; set; }
        public IEnumerable<DifficultyScale>? DifficultyScales { get; set; }
        public IEnumerable<ExpeditionParticipant>? ExpeditionParticipants { get; set; }
    }
}
