using ClimbEdge.Domain.Entities.Help;
using ClimbEdge.Domain.Repositories.Help;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Help
{
    public class EscalationRuleRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<EscalationRule>(climbEdgeContext, cacheService), IEscalationRuleRepository
    {
    }
}
