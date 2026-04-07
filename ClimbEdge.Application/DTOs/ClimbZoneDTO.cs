namespace ClimbEdge.Application.DTOs
{
    public record class CreateClimbZoneDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsPublic { get; set; } = true;
        public bool IsIndoor { get; set; } = false;
        public string? ImageUrl { get; set; }
        public long? OrganizationId { get; set; }
    }

    public record class UpdateClimbZoneDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsPublic { get; set; }
        public string? ImageUrl { get; set; }
        public long? OrganizationId { get; set; }
    }

    public record class GetClimbZoneDTO : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsPublic { get; set; }
        public bool IsIndoor { get; set; }
        public string? ImageUrl { get; set; }
        public long? OrganizationId { get; set; }
    }
}
