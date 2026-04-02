using ClimbEdge.Domain.Entities.Help;
using ClimbEdge.Domain.Repositories.Help;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Help
{
    public class HelpSearchLogRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<HelpSearchLog>(climbEdgeContext, cacheService), IHelpSearchLogRepository
    {
    }
}
