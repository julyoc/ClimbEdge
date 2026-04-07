using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Boards.Problems;
using ClimbEdge.Domain.Interfaces;
using ClimbEdge.Domain.Repositories.Boards.Problems;
using MediatR;

namespace ClimbEdge.Application.Queries.BoardProblemQuery
{
    public record GetBoardProblemsQuery(long BoardConfigId, bool IncludeArchived = false, int Page = 1, int PageSize = 20) : IRequest<IEnumerable<GetBoardProblemDTO>>;

    public class GetBoardProblemsQueryHandler : IRequestHandler<GetBoardProblemsQuery, IEnumerable<GetBoardProblemDTO>>
    {
        private readonly IBoardProblemRepository _boardProblemRepository;

        public GetBoardProblemsQueryHandler(IBoardProblemRepository boardProblemRepository)
        {
            _boardProblemRepository = boardProblemRepository;
        }

        public async Task<IEnumerable<GetBoardProblemDTO>> Handle(GetBoardProblemsQuery request, CancellationToken cancellationToken)
        {
            var problems = await _boardProblemRepository.GetAsync(
                page: request.Page,
                criteria: p => p.BoardConfigId == request.BoardConfigId
                    && !p.IsDeleted
                    && (request.IncludeArchived || !p.IsArchived),
                orderSelectors: new[] { new OrderSelectors("CreatedAt", true) },
                pageSize: request.PageSize
            );
            return problems.Select(p => Mapper.Map<BoardProblem, GetBoardProblemDTO>(p));
        }
    }
}
