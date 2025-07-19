using ClimbEdge.Common.Constants;
using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Interfaces;
using ClimbEdge.Domain.Shared;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities
{
    public class AppUser : IdentityUser<long>, IBaseEntity
    {
        public AppUser() : base() { }
        public Guid Uid { get; set; } = Guid.NewGuid();
        private string _slug = string.Empty;
        public string Slug
        {
            get => _slug;
            set => _slug = GetType().Name + "/" + value?.ToLowerInvariant().Replace(" ", "-") ?? string.Empty;
        }
        public UserProfile? UserProfile { get; set; }
        public Metadata? MetaData { get; set; }
        public byte[]? RowVersion { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? RestoredAt { get; set; }
        public DateTime? LockedAt { get; set; }
        public bool IsDeleted => DeletedAt.HasValue;
        public bool IsRestored => RestoredAt.HasValue;
        public bool IsLocked => LockedAt.HasValue;
        public int DaysSinceCreated => (DateTime.UtcNow - CreatedAt).Days;
        public int DaysSinceUpdated => UpdatedAt.HasValue ? (DateTime.UtcNow - UpdatedAt.Value).Days : 0;
        public int DaysSinceDeleted => DeletedAt.HasValue ? (DateTime.UtcNow - DeletedAt.Value).Days : 0;
        public int DaysSinceRestored => RestoredAt.HasValue ? (DateTime.UtcNow - RestoredAt.Value).Days : 0;
        public int DaysSinceLocked => LockedAt.HasValue ? (DateTime.UtcNow - LockedAt.Value).Days : 0;
        public bool IsRecentlyCreated => DaysSinceCreated <= Constants.RecentlyDaysThreshold;
        public bool IsRecentlyUpdated => DaysSinceUpdated <= Constants.RecentlyDaysThreshold;
        public bool IsRecentlyDeleted => DaysSinceDeleted <= Constants.RecentlyDaysThreshold;
        public bool IsRecentlyRestored => DaysSinceRestored <= Constants.RecentlyDaysThreshold;
        public bool IsRecentlyLocked => DaysSinceLocked <= Constants.RecentlyDaysThreshold;

        public void Lock()
        {
            LockedAt = DateTime.UtcNow;
            AddDomainEvent(new EntityDomainEvent<AppUser>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }

        public void MarkAsDeleted()
        {
            DeletedAt = DateTime.UtcNow;
            RestoredAt = null;
            AddDomainEvent(new EntityDomainEvent<AppUser>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "Deleted", true } }));
        }

        public void MarkAsRestored()
        {
            RestoredAt = DateTime.UtcNow;
            DeletedAt = null;
            AddDomainEvent(new EntityDomainEvent<AppUser>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }

        public void Unlock()
        {
            LockedAt = null;
            AddDomainEvent(new EntityDomainEvent<AppUser>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }

        public void UpdateTimestamps()
        {
            UpdatedAt = DateTime.UtcNow;
            if (IsDeleted)
            {
                RestoredAt = null;
            }
            AddDomainEvent(new EntityDomainEvent<AppUser>(Slug, EntityDomainEventType.Updated));
        }
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents() => _domainEvents.Clear();

        public bool IsTransient()
        {
            return Id == 0;
        }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Slug))
            {
                throw new InvalidOperationException("Slug cannot be null or empty.");
            }
            return true;
        }

        public void InitializeSlug()
        {
            Slug = $"{UserName}/{CreatedAt.Ticks}";
            AddDomainEvent(new EntityDomainEvent<AppUser>(Slug, EntityDomainEventType.Created));
        }
    }
}
