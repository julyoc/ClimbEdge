using ClimbEdge.Domain.Entities.Comments;
using ClimbEdge.Domain.Repositories.Comments;
using ClimbEdge.Infrastructure.Caching;
using ClimbEdge.Infrastructure.Persistence;

namespace ClimbEdge.Infrastructure.Repositories.Comments
{
    public class CommentAttachmentRepository(ClimbEdgeContext climbEdgeContext, ICacheService cacheService)
        : Repository<CommentAttachment>(climbEdgeContext, cacheService), ICommentAttachmentRepository
    {
    }
}
