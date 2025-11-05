using ClimbEdge.Domain.Entities.Boards.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Domain.Entities.DifficultyScales
{
    public sealed class DifficultyScale
    {
        public IEnumerable<BoardProblemAngle>? BoardProblemAngles { get; set; }
    }
}
