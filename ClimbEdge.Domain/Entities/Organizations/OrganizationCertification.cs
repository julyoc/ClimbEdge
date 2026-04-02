using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;

namespace ClimbEdge.Domain.Entities.Organizations
{
    public sealed class OrganizationCertification : BaseModel
    {
        public long OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        public long UserId { get; set; }
        public UserProfile? User { get; set; }
        public string CertificationType { get; set; } = string.Empty;
        public string CertificationName { get; set; } = string.Empty;
        public string? Level { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string CertificateNumber { get; set; } = string.Empty;
        public string? IssuedBy { get; set; }
        public bool IsActive { get; set; } = true;
        public bool RenewalRequired { get; set; } = false;
        public string? CertificateUrl { get; set; }
        public string? Notes { get; set; }
        public override void InitializeSlug() => Slug = CertificateNumber;
        public override void UpdateTimestamps() { base.UpdateTimestamps(); AddDomainEvent(new EntityDomainEvent<OrganizationCertification>(Slug, EntityDomainEventType.Updated)); }
        public override void MarkAsDeleted() { base.MarkAsDeleted(); AddDomainEvent(new EntityDomainEvent<OrganizationCertification>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, object> { { "deleted", true } })); }
        public override void MarkAsRestored() { base.MarkAsRestored(); AddDomainEvent(new EntityDomainEvent<OrganizationCertification>(Slug, EntityDomainEventType.Restored, new Dictionary<string, object> { { "Restored", true } })); }
        public override void Lock() { base.Lock(); AddDomainEvent(new EntityDomainEvent<OrganizationCertification>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", true } })); }
        public override void Unlock() { base.Unlock(); AddDomainEvent(new EntityDomainEvent<OrganizationCertification>(Slug, EntityDomainEventType.Locked, new Dictionary<string, object> { { "Locked", false } })); }
    }
}
