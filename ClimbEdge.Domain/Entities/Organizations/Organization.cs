using ClimbEdge.Domain.Entities.Boards;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Organizations
{
    public sealed class Organization : BaseModel
    {
        public override void InitializeSlug()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Board>? Boards { get; set; }
        public IEnumerable<Expedition>? Expeditions { get; set; }
    }
}
