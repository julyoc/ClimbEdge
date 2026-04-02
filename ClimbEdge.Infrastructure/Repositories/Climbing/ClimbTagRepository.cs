using ClimbEdge.Domain.Entities.Climbing;
using ClimbEdge.Domain.Repositories.Climbing;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Climbing
{
    public class ClimbTagRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<ClimbTag>(climbEdgeContext, cacheService), IClimbTagRepository
    {
    }
}
