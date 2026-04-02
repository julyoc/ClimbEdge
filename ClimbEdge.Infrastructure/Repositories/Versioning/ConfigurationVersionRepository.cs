using ClimbEdge.Domain.Entities.Versioning;
using ClimbEdge.Domain.Repositories.Versioning;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Versioning
{
    public class ConfigurationVersionRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<ConfigurationVersion>(climbEdgeContext, cacheService), IConfigurationVersionRepository
    {
    }
}
