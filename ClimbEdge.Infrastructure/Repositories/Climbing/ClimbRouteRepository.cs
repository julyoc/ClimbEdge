using ClimbEdge.Domain.Entities.Climbing;
using ClimbEdge.Domain.Repositories.Climbing;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Climbing
{
    public class ClimbRouteRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<ClimbRoute>(climbEdgeContext, cacheService), IClimbRouteRepository
    {
    }
}
