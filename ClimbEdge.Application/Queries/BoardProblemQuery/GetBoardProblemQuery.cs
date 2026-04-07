using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Boards.Problems;
using ClimbEdge.Domain.Repositories.Boards.Problems;
using MediatR;

namespace ClimbEdge.Application.Queries.BoardProblemQuery
{
    public record GetBoardProblemQuery(Guid ProblemUid) : IRequest<GetBoardProblemDTO?>;

    public class GetBoardProblemQueryHandler : IRequestHandler<GetBoardProblemQuery, GetBoardProblemDTO?>
    {
        private readonly IBoardProblemRepository _boardProblemRepository;

        public GetBoardProblemQueryHandler(IBoardProblemRepository boardProblemRepository)
        {
            _boardProblemRepository = boardProblemRepository;
        }

        public async Task<GetBoardProblemDTO?> Handle(GetBoardProblemQuery request, CancellationToken cancellationToken)
        {
            var problem = await _boardProblemRepository.GetAsync(request.ProblemUid);
            if (problem == null) return null;
            return Mapper.Map<BoardProblem, GetBoardProblemDTO>(problem);
        }
    }
}
