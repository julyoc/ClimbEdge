using ClimbEdge.Domain.Entities.Help;
using ClimbEdge.Domain.Repositories.Help;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Help
{
    public class HelpArticleAttachmentRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<HelpArticleAttachment>(climbEdgeContext, cacheService), IHelpArticleAttachmentRepository
    {
    }
}
