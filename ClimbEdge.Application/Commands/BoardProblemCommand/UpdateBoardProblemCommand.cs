using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Boards.Problems;
using ClimbEdge.Domain.Repositories.Boards.Problems;
using MediatR;

namespace ClimbEdge.Application.Commands.BoardProblemCommand
{
    public record UpdateBoardProblemCommand(Guid ProblemUid, UpdateBoardProblemDTO entity) : IRequest<GetBoardProblemDTO>;

    public class UpdateBoardProblemCommandHandler : IRequestHandler<UpdateBoardProblemCommand, GetBoardProblemDTO>
    {
        private readonly IBoardProblemRepository _boardProblemRepository;

        public UpdateBoardProblemCommandHandler(IBoardProblemRepository boardProblemRepository)
        {
            _boardProblemRepository = boardProblemRepository;
        }

        public async Task<GetBoardProblemDTO> Handle(UpdateBoardProblemCommand request, CancellationToken cancellationToken)
        {
            var problem = await _boardProblemRepository.GetAsync(request.ProblemUid);
            if (problem == null) throw new InvalidOperationException("Board problem not found.");
            Mapper.MapUpdate(request.entity, problem);
            problem.UpdateTimestamps();
            await _boardProblemRepository.UpdateAsync(problem);
            await _boardProblemRepository.SaveChangesAsync();
            return Mapper.Map<BoardProblem, GetBoardProblemDTO>(problem);
        }
    }
}
