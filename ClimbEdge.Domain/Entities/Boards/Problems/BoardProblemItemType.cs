using ClimbEdge.Domain.Enums.Boards;
using ClimbEdge.Domain.Shared;
using ClimbEdge.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.Boards.Problems
{
    public sealed class BoardProblemItemType : BaseModel
    {
        public HoldUsage Usage { get; set; }
        public override void InitializeSlug()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<BoardProblemItem>? BoardProblemItems { get; set; }
    }
}
