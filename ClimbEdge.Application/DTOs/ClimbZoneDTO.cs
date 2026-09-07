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
        /// <summary>Optional WKT string (POINT Z) for the zone's GPS location.</summary>
        public string? LocationWkt { get; set; }
    }

    public record class UpdateClimbZoneDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsPublic { get; set; }
        public string? ImageUrl { get; set; }
        public long? OrganizationId { get; set; }
        /// <summary>Optional WKT string (POINT Z) to update the GPS location.</summary>
        public string? LocationWkt { get; set; }
    }

    public record class GetClimbZoneDTO : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsPublic { get; set; }
        public bool IsIndoor { get; set; }
        public string? ImageUrl { get; set; }
        public long? OrganizationId { get; set; }
        /// <summary>Latitude of the zone, if available.</summary>
        public double? Latitude { get; set; }
        /// <summary>Longitude of the zone, if available.</summary>
        public double? Longitude { get; set; }
    }
}
