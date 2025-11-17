using ClimbEdge.Domain.Enums;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Mountains
{
    public sealed class RouteFile : BaseModel
    {
        public long MountainRouteId { get; set; }
        public MountainRoute? MountainRoute { get; set; }
        public FileType FileType { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string FileUrl { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsOfficial { get; set; } = true;
        public long UploadedBy { get; set; }
        public UserProfile? UploadedUserProfile { get; set; }
        public override void InitializeSlug()
        {
            throw new NotImplementedException();
        }
    }
}
