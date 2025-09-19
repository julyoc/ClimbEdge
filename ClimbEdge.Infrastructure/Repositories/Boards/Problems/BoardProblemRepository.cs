using ClimbEdge.Domain.Entities.Boards.Problems;
using ClimbEdge.Domain.Repositories.Boards.Problems;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Repositories.Boards.Problems
{
    public class BoardProblemRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService) : Repository<BoardProblem>(climbEdgeContext, cacheService), IBoardProblemRepository
    {
    }
}
