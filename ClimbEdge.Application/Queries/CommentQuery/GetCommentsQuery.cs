using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Comments;
using ClimbEdge.Domain.Repositories.Comments;
using MediatR;

namespace ClimbEdge.Application.Queries.CommentQuery
{
    public record GetCommentsQuery(string EntityType, long EntityId) : IRequest<IEnumerable<GetCommentDTO>>;

    public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, IEnumerable<GetCommentDTO>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentsQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<GetCommentDTO>> Handle(
            GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetAsync(
                criteria: c => c.EntityType == request.EntityType
                    && c.EntityId == request.EntityId
                    && c.ParentCommentId == null
                    && !c.IsDeleted);

            return comments
                .OrderByDescending(c => c.IsPinned)
                .ThenBy(c => c.CreatedAt)
                .Select(c => Mapper.Map<Comment, GetCommentDTO>(c));
        }
    }
}
