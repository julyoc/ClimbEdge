using ClimbEdge.Domain.Enums.Boards;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Boards
{
    public sealed class BoardAngle : BaseModel
    {
        public int Angle { get; set; }
        public AngleUnit Unit { get; set; } = AngleUnit.Degrees;
        public string? Description { get; set; }
        public override void InitializeSlug()
        {
            Slug = $"{Angle}{(Unit == AngleUnit.Degrees ? "°" : "rad")}";
        }
    }
}
