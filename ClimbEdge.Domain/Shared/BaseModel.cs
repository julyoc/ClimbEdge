using ClimbEdge.Common.Constants;
using ClimbEdge.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace ClimbEdge.Domain.Shared
{
    /// <summary>
    /// Modelo base para todas las entidades del dominio
    /// </summary>
    public abstract class BaseModel : IBaseEntity
    {
        /// <summary>
        /// Identificador único de la entidad
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Identificador único universal (GUID) para la entidad
        /// </summary>
        public Guid Uid { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Slug para URL amigable, generado automáticamente
        /// </summary>  
        private string _slug = string.Empty;
        /// <summary>
        /// Slug para URL amigable, generado automáticamente
        /// </summary>
        public string Slug
        {
            get => _slug;
            set => _slug = GetType().Name + "/" + value?.ToLowerInvariant().Replace(" ", "-") ?? string.Empty;
        }
        /// <summary>
        /// Metadatos adicionales en formato JSON
        /// </summary>
        public Metadata? MetaData { get; set; }

        /// <summary>
        /// Versión de concurrencia para control de cambios
        /// </summary>
        public byte[]? RowVersion { get; set; }
        /// <summary>
        /// Fecha de creación del registro
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// Fecha de actualización del registro
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
        /// <summary>
        /// Fecha de eliminación del registro (soft delete)
        /// </summary>
        public DateTime? DeletedAt { get; set; }
        /// <summary>
        /// Fecha de restauración del registro (soft delete)
        /// </summary>
        public DateTime? RestoredAt { get; set; }
        /// <summary>
        /// Fecha de bloqueo del registro (para evitar modificaciones concurrentes)
        /// </summary>
        public DateTime? LockedAt { get; set; }
        /// <summary>
        /// Indica si el registro ha sido eliminado (soft delete)
        /// </summary>
        public bool IsDeleted => DeletedAt.HasValue;
        /// <summary>
        /// Indica si el registro ha sido restaurado después de un soft delete
        /// </summary>
        public bool IsRestored => RestoredAt.HasValue;
        /// <summary>
        /// Indica si el registro está bloqueado para modificaciones
        /// </summary>
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
        /// <summary>
        /// Representación en cadena del modelo base
        /// </summary>
        /// <returns>
        /// Una cadena que representa el modelo base, incluyendo sus propiedades clave.
        /// </returns>
        public override string ToString()
        {
            return Id == 0 ?
                $"{GetType().Name} [New Instance]"
                    :
                $"{GetType().Name} [Id={Id}, Uid={Uid}, Slug={Slug}, CreatedAt={CreatedAt}, UpdatedAt={UpdatedAt}, IsDeleted={IsDeleted}, IsRestored={IsRestored}]";
        }
        /// <summary>
        /// Compara si dos instancias de BaseModel son iguales basándose en Id y Uid.
        /// </summary>
        /// <param name="obj">El objeto a comparar con la instancia actual.</param>
        /// <returns>True si el objeto es una instancia de BaseModel y sus Id y Uid son iguales; de lo contrario, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is BaseModel other)
            {
                return Id == other.Id && Uid == other.Uid;
            }
            return false;
        }
        /// <summary>
        /// Obtiene el código hash de la instancia actual.
        /// </summary>
        /// <returns>Un entero que representa el código hash de la instancia actual, basado en Id y Uid.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Uid);
        }
        /// <summary>
        /// Determina si la entidad es transitoria (no persistida en la base de datos).
        /// </summary>
        /// <returns>True si la entidad es transitoria (Id es 0); de lo contrario, false.</returns>
        public virtual bool IsTransient()
        {
            return Id == 0;
        }
        /// <summary>
        /// Valida el modelo base.
        /// </summary>
        public virtual bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Slug))
            {
                throw new InvalidOperationException("Slug cannot be null or empty.");
            }
            return true;
        }
        /// <summary>
        /// Marca la entidad como eliminada (soft delete).
        /// </summary>
        public virtual void MarkAsDeleted()
        {
            DeletedAt = DateTime.UtcNow;
            RestoredAt = null;
        }
        /// <summary>
        /// Marca la entidad como restaurada después de un soft delete.
        /// </summary>
        public virtual void MarkAsRestored()
        {
            RestoredAt = DateTime.UtcNow;
            DeletedAt = null;
        }
        /// <summary>
        /// Actualiza las marcas de tiempo de creación y actualización.
        /// </summary>
        public virtual void UpdateTimestamps()
        {
            UpdatedAt = DateTime.UtcNow;
            if (IsDeleted)
            {
                RestoredAt = null;
            }
        }
        public virtual void Lock()
        {
            LockedAt = DateTime.UtcNow;
        }
        public virtual void Unlock()
        {
            LockedAt = null;
        }
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}