using ClimbEdge.Domain.Entities.Training;
using ClimbEdge.Domain.Repositories.Training;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Training
{
    public class FitnessTestRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<FitnessTest>(climbEdgeContext, cacheService), IFitnessTestRepository
    {
    }
}
