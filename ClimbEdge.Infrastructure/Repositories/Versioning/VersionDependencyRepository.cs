using ClimbEdge.Domain.Entities.Versioning;
using ClimbEdge.Domain.Repositories.Versioning;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Versioning
{
    public class VersionDependencyRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<VersionDependency>(climbEdgeContext, cacheService), IVersionDependencyRepository
    {
    }
}
