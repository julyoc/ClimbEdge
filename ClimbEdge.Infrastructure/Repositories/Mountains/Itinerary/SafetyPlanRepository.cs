using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Mountains.Itinerary
{
    public class SafetyPlanRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<SafetyPlan>(climbEdgeContext, cacheService), ISafetyPlanRepository
    {
    }
}
