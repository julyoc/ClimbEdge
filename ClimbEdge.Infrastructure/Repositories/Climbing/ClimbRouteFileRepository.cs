using ClimbEdge.Domain.Entities.Climbing;
using ClimbEdge.Domain.Repositories.Climbing;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Climbing
{
    public class ClimbRouteFileRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<ClimbRouteFile>(climbEdgeContext, cacheService), IClimbRouteFileRepository
    {
    }
}
