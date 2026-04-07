using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Comments;
using ClimbEdge.Domain.Repositories.Comments;
using MediatR;

namespace ClimbEdge.Application.Commands.CommentCommand
{
    public record UpdateCommentCommand(Guid CommentUid, UpdateCommentDTO entity) : IRequest<GetCommentDTO>;

    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, GetCommentDTO>
    {
        private readonly ICommentRepository _commentRepository;

        public UpdateCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<GetCommentDTO> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetAsync(request.CommentUid)
                ?? throw new InvalidOperationException("Comment not found.");

            comment.Content = request.entity.Content;
            comment.IsEdited = true;
            comment.EditedAt = DateTime.UtcNow;
            comment.UpdateTimestamps();
            await _commentRepository.UpdateAsync(comment);
            await _commentRepository.SaveChangesAsync();
            return Mapper.Map<Comment, GetCommentDTO>(comment);
        }
    }
}
