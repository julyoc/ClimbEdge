using ClimbEdge.Domain.Repositories.Boards;
using MediatR;

namespace ClimbEdge.Application.Commands.BoardCommand
{
    public record DeleteBoardCommand(Guid BoardUid) : IRequest;

    public class DeleteBoardCommandHandler : IRequestHandler<DeleteBoardCommand>
    {
        private readonly IBoardRepository _boardRepository;

        public DeleteBoardCommandHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public async Task Handle(DeleteBoardCommand request, CancellationToken cancellationToken)
        {
            var exists = await _boardRepository.ExistsAsync(request.BoardUid);
            if (!exists) throw new InvalidOperationException("Board not found.");
            await _boardRepository.DeleteAsync(request.BoardUid);
            await _boardRepository.SaveChangesAsync();
        }
    }
}
