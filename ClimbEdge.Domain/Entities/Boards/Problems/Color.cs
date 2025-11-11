using ClimbEdge.Domain.DomainEvents;
using ClimbEdge.Domain.Shared;
using ClimbEdge.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Boards.Problems
{
    public sealed class Color : BaseModel
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        private ColorHex colorHex { get; set; }
        public ColorHex ColorHex { get { return colorHex; } set { colorHex = value; ColorRgb = value.ToRgb(); ColorHsl = ColorRgb.ToHsl(); } }
        public string HexCode
        {
            get 
            {
                string clean = ColorHex.HexCode.Replace("#", "").Trim();
                return $"#{clean}";
            }
        }
        public ColorRgb ColorRgb { get; private set; }
        public string Rgb
        {
            get { return $"rgb ({this.ColorRgb.RgbRed}, {this.ColorRgb.RgbGreen}, {this.ColorRgb.RgbBlue})"; }
        }
        public ColorHsl ColorHsl { get; private set; }
        public string Hsl
        {
            get { return $"hsl ({this.ColorHsl.HslHue}, {this.ColorHsl.HslSaturation}%, {this.ColorHsl.HslLightness}%)"; }
        }
        public bool IsStandard { get; set; } = true;
        public override void InitializeSlug()
        {
            Slug = Name;
        }
        public override void UpdateTimestamps()
        {
            base.UpdateTimestamps();
            AddDomainEvent(new EntityDomainEvent<Color>(Slug, EntityDomainEventType.Updated));
        }
        public override void MarkAsDeleted()
        {
            base.MarkAsDeleted();
            AddDomainEvent(new EntityDomainEvent<Color>(Slug, EntityDomainEventType.Deleted, new Dictionary<string, Object>() { { "deleted", true } }));
        }
        public override void MarkAsRestored()
        {
            base.MarkAsRestored();
            AddDomainEvent(new EntityDomainEvent<Color>(Slug, EntityDomainEventType.Restored, new Dictionary<string, Object>() { { "Restored", true } }));
        }
        public override void Lock()
        {
            base.Lock();
            AddDomainEvent(new EntityDomainEvent<Color>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", true } }));
        }
        public override void Unlock()
        {
            base.Unlock();
            AddDomainEvent(new EntityDomainEvent<Color>(Slug, EntityDomainEventType.Locked, new Dictionary<string, Object>() { { "Locked", false } }));
        }
        public IEnumerable<BoardProblemItemType>? boardProblemItemTypes { get; set; }
    }
}
