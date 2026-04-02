using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Entities.Boards;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Enums.Organizations;
using ClimbEdge.Domain.Shared;
using NetTopologySuite.Geometries;

namespace ClimbEdge.Domain.Entities.Organizations
{
    public sealed class Organization : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public OrganizationType Type { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string Country { get; set; } = string.Empty;
        public string? PostalCode { get; set; }
        public Point? Location { get; set; }
        public string? TimeZone { get; set; }
        public bool IsVerified { get; set; } = false;
        public bool IsPublic { get; set; } = true;
        public string? LogoUrl { get; set; }
        public string? BannerUrl { get; set; }
        public DateTime? FoundedDate { get; set; }
        public string? LicenseNumber { get; set; }
        public string? TaxId { get; set; }
        public IDictionary<string, object>? BusinessHours { get; set; }
        public IDictionary<string, object>? SocialMedia { get; set; }
        public IDictionary<string, object>? Amenities { get; set; }
        public IDictionary<string, object>? SafetyCertifications { get; set; }
        public IEnumerable<Board>? Boards { get; set; }
        public IEnumerable<Expedition>? Expeditions { get; set; }
        public IEnumerable<OrganizationMember>? Members { get; set; }
        public IEnumerable<OrganizationFacility>? Facilities { get; set; }
        public IEnumerable<OrganizationEvent>? Events { get; set; }
        public IEnumerable<OrganizationInstructor>? Instructors { get; set; }
        public IEnumerable<OrganizationFile>? Files { get; set; }
        public override void InitializeSlug() => Slug = Name;
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<Organization>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<Organization>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<Organization>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<Organization>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<Organization>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
