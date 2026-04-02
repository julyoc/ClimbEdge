using ClimbEdge.Domain.Entities.Payment;
using ClimbEdge.Domain.Repositories.Payment;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Payment
{
    public class SubscriptionRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<Subscription>(climbEdgeContext, cacheService), ISubscriptionRepository
    {
    }
}
