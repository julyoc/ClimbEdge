using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Boards
{
    public sealed class BoardConfig : BaseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Version { get; set; } = "1.0.0";
        public bool IsActive { get; set; } = true;
        public long? PreviousVersionId { get; set; }
        public BoardConfig? PreviousVersion { get; set; }
        public IEnumerable<BoardConfig>? NextVersions { get; set; }
        public string Content { get; set; }
        public int Cols { get; set; }
        public int Rows { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        /// <summary>
        /// Espaciado vertical entre los ítems en la cuadrícula
        /// </summary>
        public float InterItemSpacingVertical { get; set; }
        /// <summary>
        /// Espaciado horizontal entre los ítems en la cuadrícula
        /// </summary>
        public float InterItemSpacingHorizontal { get; set; }
        /// <summary>
        /// Indica si la cuadrícula es de tipo "staggered" (escalonada)
        /// true para cuadrículas escalonadas, false para cuadrículas regulares
        /// </summary>
        public bool IsStaggeredGrid { get; set; } = false;
        public float StaggeredGridOffset { get; set; }
        public int? Difficulty { get; set; }
        public long CreatedByUserId { get; set; }
        public UserProfile CreatedByUser { get; set; }
        public long? ApprovedByUserId { get; set; }
        public UserProfile? ApprovedByUser { get; set; }
        public DateTime ApprovedAt { get; set; }
        public string? ChangeNotes { get; set; }
        public bool IsBackwardCompatible { get; set; } = true;
        /// <summary>
        /// Instrucciones para migrar desde versiones anteriores
        /// </summary>
        public string? MigrationScript { get; set; }
        public BoardConfig() { }
        public override void InitializeSlug()
        {
            Slug = $"{Name}({Cols},{Width.ToString("0.000")})X({Rows},{Height.ToString("0.000")})";
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<BoardConfig>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<BoardConfig>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<BoardConfig>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<BoardConfig>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<BoardConfig>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
        public IEnumerable<Board>? Boards { get; set; }
    }
}
