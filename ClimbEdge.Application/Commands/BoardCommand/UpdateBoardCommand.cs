using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Boards;
using ClimbEdge.Domain.Repositories.Boards;
using MediatR;

namespace ClimbEdge.Application.Commands.BoardCommand
{
    public record UpdateBoardCommand(Guid BoardUid, UpdateBoardDTO entity) : IRequest<GetBoardDTO>;

    public class UpdateBoardCommandHandler : IRequestHandler<UpdateBoardCommand, GetBoardDTO>
    {
        private readonly IBoardRepository _boardRepository;

        public UpdateBoardCommandHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public async Task<GetBoardDTO> Handle(UpdateBoardCommand request, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetAsync(request.BoardUid);
            if (board == null) throw new InvalidOperationException("Board not found.");
            Mapper.MapUpdate(request.entity, board);
            board.UpdateTimestamps();
            await _boardRepository.UpdateAsync(board);
            await _boardRepository.SaveChangesAsync();
            return Mapper.Map<Board, GetBoardDTO>(board);
        }
    }
}
