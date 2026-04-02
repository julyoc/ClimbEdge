using ClimbEdge.Domain.Entities.Help;
using ClimbEdge.Domain.Repositories.Help;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Help
{
    public class SupportAgentRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<SupportAgent>(climbEdgeContext, cacheService), ISupportAgentRepository
    {
    }
}
