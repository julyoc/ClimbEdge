using ClimbEdge.Domain.Repositories.Boards.Problems;
using MediatR;

namespace ClimbEdge.Application.Commands.BoardProblemCommand
{
    public record DeleteBoardProblemCommand(Guid ProblemUid) : IRequest;

    public class DeleteBoardProblemCommandHandler : IRequestHandler<DeleteBoardProblemCommand>
    {
        private readonly IBoardProblemRepository _boardProblemRepository;

        public DeleteBoardProblemCommandHandler(IBoardProblemRepository boardProblemRepository)
        {
            _boardProblemRepository = boardProblemRepository;
        }

        public async Task Handle(DeleteBoardProblemCommand request, CancellationToken cancellationToken)
        {
            var exists = await _boardProblemRepository.ExistsAsync(request.ProblemUid);
            if (!exists) throw new InvalidOperationException("Board problem not found.");
            await _boardProblemRepository.DeleteAsync(request.ProblemUid);
            await _boardProblemRepository.SaveChangesAsync();
        }
    }
}
