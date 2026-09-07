using ClimbEdge.Domain.Shared;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Mountains
{
    public sealed class RouteTrack : BaseModel
    {
        public long MountainRouteId { get; set; }
        public MountainRoute? MountainRoute { get; set; }
        public string Name { get; set; }
        public LineString TrackData { get; set; }
        /// <summary>
        /// Total distance in kilometers
        /// </summary>
        public float TotalDistance { get; set; }
        public int MinElevation { get; set; }
        public int MaxElevation { get; set; }
        public string? RecordedBy { get; set; }
        public DateTime? RecordedAt { get; set; }
        public string? GpsDevice { get; set; }
        public float? Accuracy { get; set; }
        public override void InitializeSlug()
        {
            Slug = $"routetrack-{MountainRouteId}-{CreatedAt.Ticks}";
        }
    }
}
