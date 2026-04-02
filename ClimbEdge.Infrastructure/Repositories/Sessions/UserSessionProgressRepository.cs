using ClimbEdge.Domain.Entities.Sessions;
using ClimbEdge.Domain.Repositories.Sessions;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Sessions
{
    public class UserSessionProgressRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<UserSessionProgress>(climbEdgeContext, cacheService), IUserSessionProgressRepository
    {
    }
}
