using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Boards.Problems;
using ClimbEdge.Domain.Repositories.Boards.Problems;
using MediatR;

namespace ClimbEdge.Application.Commands.BoardProblemCommand
{
    public record ArchiveBoardProblemCommand(Guid ProblemUid) : IRequest<GetBoardProblemDTO>;

    public class ArchiveBoardProblemCommandHandler : IRequestHandler<ArchiveBoardProblemCommand, GetBoardProblemDTO>
    {
        private readonly IBoardProblemRepository _boardProblemRepository;

        public ArchiveBoardProblemCommandHandler(IBoardProblemRepository boardProblemRepository)
        {
            _boardProblemRepository = boardProblemRepository;
        }

        public async Task<GetBoardProblemDTO> Handle(ArchiveBoardProblemCommand request, CancellationToken cancellationToken)
        {
            var problem = await _boardProblemRepository.GetAsync(request.ProblemUid);
            if (problem == null) throw new InvalidOperationException("Board problem not found.");
            problem.IsArchived = true;
            problem.UpdateTimestamps();
            await _boardProblemRepository.UpdateAsync(problem);
            await _boardProblemRepository.SaveChangesAsync();
            return Mapper.Map<BoardProblem, GetBoardProblemDTO>(problem);
        }
    }
}
