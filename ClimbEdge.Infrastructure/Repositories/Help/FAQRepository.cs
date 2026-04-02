using ClimbEdge.Domain.Entities.Help;
using ClimbEdge.Domain.Repositories.Help;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Help
{
    public class FAQRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<FAQ>(climbEdgeContext, cacheService), IFAQRepository
    {
    }
}
