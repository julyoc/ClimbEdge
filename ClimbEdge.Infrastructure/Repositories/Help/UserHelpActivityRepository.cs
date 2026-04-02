using ClimbEdge.Domain.Entities.Help;
using ClimbEdge.Domain.Repositories.Help;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Help
{
    public class UserHelpActivityRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<UserHelpActivity>(climbEdgeContext, cacheService), IUserHelpActivityRepository
    {
    }
}
