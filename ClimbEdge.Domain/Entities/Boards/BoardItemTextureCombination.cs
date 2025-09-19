using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Boards
{
    public sealed class BoardItemTextureCombination : BaseModel
    {
        public long BoardItemId { get; set; }
        public BoardItem? BoardItem { get; set; }
        public long BoardItemTextureId { get; set; }
        public BoardItemTexture? BoardItemTexture { get; set; }
        public long BoardItemTextureMaterialId { get; set; }
        public BoardItemTextureMaterial? BoardItemTextureMaterial { get; set; }
        /// <summary>
        /// Porcentaje de cobertura de esta textura en la presa (0-100)
        /// </summary>
        public float Percentage { get; set; } = 100;
        /// <summary>
        /// Orden de aplicación de las texturas en sentido horario (para efectos visuales)
        /// </summary>
        public int Order { get; set; } = 1;
        /// <summary>
        /// Indica si esta es la textura primaria del ítem
        /// </summary>
        public bool IsPrimary { get; set; } = true;
        public bool IsActive { get; set; } = true;
        public BoardItemTextureCombination() { }
        public override void InitializeSlug()
        {
            Slug = $"{BoardItemId}-{BoardItemTextureId}-{BoardItemTextureMaterialId}-{Percentage}-{Order}".ToLower();
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<BoardItemTextureCombination>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<BoardItemTextureCombination>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<BoardItemTextureCombination>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<BoardItemTextureCombination>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<BoardItemTextureCombination>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
    }
}
