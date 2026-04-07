using ClimbEdge.Domain.Repositories.Comments;
using MediatR;

namespace ClimbEdge.Application.Commands.CommentCommand
{
    public record DeleteCommentCommand(Guid CommentUid) : IRequest;

    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            await _commentRepository.DeleteAsync(request.CommentUid);
            await _commentRepository.SaveChangesAsync();
        }
    }
}
