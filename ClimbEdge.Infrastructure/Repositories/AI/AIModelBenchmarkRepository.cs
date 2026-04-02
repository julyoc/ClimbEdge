using ClimbEdge.Domain.Entities.AI;
using ClimbEdge.Domain.Repositories.AI;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.AI
{
    public class AIModelBenchmarkRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<AIModelBenchmark>(climbEdgeContext, cacheService), IAIModelBenchmarkRepository
    {
    }
}
