using ClimbEdge.Domain.Entities.AI;
using ClimbEdge.Domain.Repositories.AI;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.AI
{
    public class AITrainingSessionRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<AITrainingSession>(climbEdgeContext, cacheService), IAITrainingSessionRepository
    {
    }
}
