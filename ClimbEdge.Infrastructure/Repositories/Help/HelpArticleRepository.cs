using ClimbEdge.Domain.Entities.Help;
using ClimbEdge.Domain.Repositories.Help;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Help
{
    public class HelpArticleRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<HelpArticle>(climbEdgeContext, cacheService), IHelpArticleRepository
    {
    }
}
