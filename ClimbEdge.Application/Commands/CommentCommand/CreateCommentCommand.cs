using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Comments;
using ClimbEdge.Domain.Repositories.Comments;
using MediatR;

namespace ClimbEdge.Application.Commands.CommentCommand
{
    public record CreateCommentCommand(CreateCommentDTO entity) : IRequest<GetCommentDTO>;

    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, GetCommentDTO>
    {
        private readonly ICommentRepository _commentRepository;

        public CreateCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<GetCommentDTO> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = Mapper.Map<CreateCommentDTO, Comment>(request.entity);
            comment.InitializeSlug();
            await _commentRepository.AddAsync(comment);
            await _commentRepository.SaveChangesAsync();
            return Mapper.Map<Comment, GetCommentDTO>(comment);
        }
    }
}
