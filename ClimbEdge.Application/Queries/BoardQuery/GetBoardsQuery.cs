using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Boards;
using ClimbEdge.Domain.Interfaces;
using ClimbEdge.Domain.Repositories.Boards;
using MediatR;

namespace ClimbEdge.Application.Queries.BoardQuery
{
    public record GetBoardsQuery(long? OrganizationId = null, int Page = 1, int PageSize = 20) : IRequest<IEnumerable<GetBoardDTO>>;

    public class GetBoardsQueryHandler : IRequestHandler<GetBoardsQuery, IEnumerable<GetBoardDTO>>
    {
        private readonly IBoardRepository _boardRepository;

        public GetBoardsQueryHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public async Task<IEnumerable<GetBoardDTO>> Handle(GetBoardsQuery request, CancellationToken cancellationToken)
        {
            var boards = await _boardRepository.GetAsync(
                page: request.Page,
                criteria: b => !b.IsDeleted && (request.OrganizationId == null || b.OrganizationId == request.OrganizationId),
                orderSelectors: new[] { new OrderSelectors("CreatedAt", true) },
                pageSize: request.PageSize
            );
            return boards.Select(b => Mapper.Map<Board, GetBoardDTO>(b));
        }
    }
}
