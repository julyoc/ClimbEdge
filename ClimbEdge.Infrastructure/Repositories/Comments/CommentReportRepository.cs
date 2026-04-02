using ClimbEdge.Domain.Entities.Comments;
using ClimbEdge.Domain.Repositories.Comments;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Comments
{
    public class CommentReportRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<CommentReport>(climbEdgeContext, cacheService), ICommentReportRepository
    {
    }
}
