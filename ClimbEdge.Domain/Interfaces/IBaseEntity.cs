using ClimbEdge.Domain.Shared;
using System.Numerics;

namespace ClimbEdge.Domain.Interfaces
{
    /// <summary>
    /// Interfaz para entidades que implementan propiedades de BaseModel
    /// </summary>
    public interface IBaseEntity
    {
        long Id { get; set; }
        Guid Uid { get; set; }
        string Slug { get; set; }
        Metadata? MetaData { get; set; }
        byte[]? RowVersion { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        DateTime? DeletedAt { get; set; }
        DateTime? RestoredAt { get; set; }
        DateTime? LockedAt { get; set; }

        bool IsDeleted { get; }
        bool IsRestored { get; }
        bool IsLocked { get; }

        int DaysSinceCreated { get; }
        int DaysSinceUpdated { get; }
        int DaysSinceDeleted { get; }
        int DaysSinceRestored { get; }
        int DaysSinceLocked { get; }

        bool IsRecentlyCreated { get; }
        bool IsRecentlyUpdated { get; }
        bool IsRecentlyDeleted { get; }
        bool IsRecentlyRestored { get; }
        bool IsRecentlyLocked { get; }

        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

        bool IsTransient();
        bool IsValid();
        void MarkAsDeleted();
        void MarkAsRestored();
        void UpdateTimestamps();
        void Lock();
        void Unlock();
        void ClearDomainEvents();
    }
}
