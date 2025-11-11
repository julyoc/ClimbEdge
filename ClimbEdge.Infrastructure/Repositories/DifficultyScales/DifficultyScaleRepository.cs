using ClimbEdge.Domain.Entities.Boards;
using ClimbEdge.Domain.Entities.DifficultyScales;
using ClimbEdge.Domain.Repositories.Boards;
using ClimbEdge.Domain.Repositories.DifficultyScales;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Repositories.DifficultyScales
{
    public class DifficultyScaleRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService) : Repository<DifficultyScale>(climbEdgeContext, cacheService), IDifficultyScaleRepository
    {
    }
}
