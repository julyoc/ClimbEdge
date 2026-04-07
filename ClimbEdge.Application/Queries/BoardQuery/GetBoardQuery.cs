using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Boards;
using ClimbEdge.Domain.Repositories.Boards;
using MediatR;

namespace ClimbEdge.Application.Queries.BoardQuery
{
    public record GetBoardQuery(Guid BoardUid) : IRequest<GetBoardDTO?>;

    public class GetBoardQueryHandler : IRequestHandler<GetBoardQuery, GetBoardDTO?>
    {
        private readonly IBoardRepository _boardRepository;

        public GetBoardQueryHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public async Task<GetBoardDTO?> Handle(GetBoardQuery request, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetAsync(request.BoardUid);
            if (board == null) return null;
            return Mapper.Map<Board, GetBoardDTO>(board);
        }
    }
}
