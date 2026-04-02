using ClimbEdge.Domain.Entities.Climbing;
using ClimbEdge.Domain.Repositories.Climbing;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Climbing
{
    public class ClimbZoneFileRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<ClimbZoneFile>(climbEdgeContext, cacheService), IClimbZoneFileRepository
    {
    }
}
