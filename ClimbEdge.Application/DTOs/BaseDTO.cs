using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Application.DTOs
{
    public abstract class BaseDTO
    {
        public Guid Uid { get; set; }
        public string Slug { get; set; } = string.Empty;
        public Metadata? MetaData { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? RestoredAt { get; set; }
        public DateTime? LockedAt { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsRestored { get; set; }
        public bool IsLocked { get; set; }
        public int DaysSinceCreated { get; set; }
        public int DaysSinceUpdated { get; set; }
        public int DaysSinceDeleted { get; set; }
        public int DaysSinceRestored { get; set; }
        public int DaysSinceLocked { get; set; }
        public bool IsRecentlyCreated { get; set; }
        public bool IsRecentlyUpdated { get; set; }
        public bool IsRecentlyDeleted { get; set; }
        public bool IsRecentlyRestored { get; set; }
        public bool IsRecentlyLocked { get; set; }
    }
}
