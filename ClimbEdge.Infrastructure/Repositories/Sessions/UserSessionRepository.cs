using ClimbEdge.Domain.Entities.Sessions;
using ClimbEdge.Domain.Repositories.Sessions;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Sessions
{
    public class UserSessionRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<UserSession>(climbEdgeContext, cacheService), IUserSessionRepository
    {
    }
}
