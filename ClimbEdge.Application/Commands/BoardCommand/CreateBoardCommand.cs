using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Boards;
using ClimbEdge.Domain.Repositories.Boards;
using MediatR;

namespace ClimbEdge.Application.Commands.BoardCommand
{
    public record CreateBoardCommand(CreateBoardDTO entity) : IRequest<GetBoardDTO>;

    public class CreateBoardCommandHandler : IRequestHandler<CreateBoardCommand, GetBoardDTO>
    {
        private readonly IBoardRepository _boardRepository;

        public CreateBoardCommandHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public async Task<GetBoardDTO> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            var board = Mapper.Map<CreateBoardDTO, Board>(request.entity);
            await _boardRepository.AddAsync(board);
            await _boardRepository.SaveChangesAsync();
            return Mapper.Map<Board, GetBoardDTO>(board);
        }
    }
}
