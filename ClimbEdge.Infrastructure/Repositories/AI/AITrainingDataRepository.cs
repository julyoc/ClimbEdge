using ClimbEdge.Domain.Entities.AI;
using ClimbEdge.Domain.Repositories.AI;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.AI
{
    public class AITrainingDataRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<AITrainingData>(climbEdgeContext, cacheService), IAITrainingDataRepository
    {
    }
}
