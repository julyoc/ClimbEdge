using ClimbEdge.Domain.Enums.Organizations;

namespace ClimbEdge.Application.DTOs
{
    public record class CreateOrganizationDTO
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
        public string? TimeZone { get; set; }
        public string? LogoUrl { get; set; }
        public DateTime? FoundedDate { get; set; }
    }

    public record class UpdateOrganizationDTO
    {
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? TimeZone { get; set; }
        public string? LogoUrl { get; set; }
        public string? BannerUrl { get; set; }
        public bool? IsPublic { get; set; }
    }

    public record class GetOrganizationDTO : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public OrganizationType Type { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? City { get; set; }
        public string Country { get; set; } = string.Empty;
        public bool IsVerified { get; set; }
        public bool IsPublic { get; set; }
        public string? LogoUrl { get; set; }
        public string? BannerUrl { get; set; }
    }

    public record class AddOrganizationMemberDTO
    {
        public long OrganizationId { get; set; }
        public long UserId { get; set; }
        public MembershipType MembershipType { get; set; } = MembershipType.Basic;
    }

    public record class RemoveOrganizationMemberDTO
    {
        public long OrganizationId { get; set; }
        public long UserId { get; set; }
    }

    public record class GetOrganizationMemberDTO : BaseDTO
    {
        public long OrganizationId { get; set; }
        public long UserId { get; set; }
        public MembershipType MembershipType { get; set; }
        public MembershipStatus Status { get; set; }
        public string? Role { get; set; }
        public DateTime JoinedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }

    public record class CreateOrganizationEventDTO
    {
        public long OrganizationId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string EventType { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Location { get; set; }
        public long? FacilityId { get; set; }
        public int? MaxParticipants { get; set; }
        public DateTime? RegistrationDeadline { get; set; }
        public decimal? Cost { get; set; }
        public string? Currency { get; set; }
        public bool RequiresRegistration { get; set; } = false;
        public bool IsPublic { get; set; } = true;
        public string? SkillLevelRequired { get; set; }
        public string? Instructor { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
    }

    public record class UpdateOrganizationEventDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Location { get; set; }
        public int? MaxParticipants { get; set; }
        public DateTime? RegistrationDeadline { get; set; }
        public string? Status { get; set; }
        public bool? IsPublic { get; set; }
    }

    public record class GetOrganizationEventDTO : BaseDTO
    {
        public long OrganizationId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string EventType { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Location { get; set; }
        public int? MaxParticipants { get; set; }
        public int CurrentParticipants { get; set; }
        public decimal? Cost { get; set; }
        public string? Currency { get; set; }
        public bool IsPublic { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public record class RegisterEventParticipantDTO
    {
        public long EventId { get; set; }
        public long UserId { get; set; }
        public string? Notes { get; set; }
    }

    public record class GetOrganizationEventParticipantDTO : BaseDTO
    {
        public long EventId { get; set; }
        public long UserId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? PaymentStatus { get; set; }
        public DateTime? CheckInTime { get; set; }
    }
}
