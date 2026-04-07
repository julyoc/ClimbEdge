using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Comments;
using ClimbEdge.Domain.Repositories.Comments;
using MediatR;

namespace ClimbEdge.Application.Queries.CommentQuery
{
    public record GetCommentRepliesQuery(long ParentCommentId) : IRequest<IEnumerable<GetCommentDTO>>;

    public class GetCommentRepliesQueryHandler : IRequestHandler<GetCommentRepliesQuery, IEnumerable<GetCommentDTO>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentRepliesQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<GetCommentDTO>> Handle(
            GetCommentRepliesQuery request, CancellationToken cancellationToken)
        {
            var replies = await _commentRepository.GetAsync(
                criteria: c => c.ParentCommentId == request.ParentCommentId && !c.IsDeleted);

            return replies
                .OrderBy(c => c.CreatedAt)
                .Select(c => Mapper.Map<Comment, GetCommentDTO>(c));
        }
    }
}
