using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Boards.Problems;
using ClimbEdge.Domain.Repositories.Boards.Problems;
using MediatR;

namespace ClimbEdge.Application.Commands.BoardProblemCommand
{
    public record CreateBoardProblemCommand(CreateBoardProblemDTO entity) : IRequest<GetBoardProblemDTO>;

    public class CreateBoardProblemCommandHandler : IRequestHandler<CreateBoardProblemCommand, GetBoardProblemDTO>
    {
        private readonly IBoardProblemRepository _boardProblemRepository;

        public CreateBoardProblemCommandHandler(IBoardProblemRepository boardProblemRepository)
        {
            _boardProblemRepository = boardProblemRepository;
        }

        public async Task<GetBoardProblemDTO> Handle(CreateBoardProblemCommand request, CancellationToken cancellationToken)
        {
            var existing = await _boardProblemRepository.GetAsync(
                criteria: p => p.BoardConfigId == request.entity.BoardConfigId
                    && p.Name == request.entity.Name && !p.IsDeleted);
            if (existing.Any()) throw new InvalidOperationException("A problem with this name already exists on this board.");

            var problem = Mapper.Map<CreateBoardProblemDTO, BoardProblem>(request.entity);
            await _boardProblemRepository.AddAsync(problem);
            await _boardProblemRepository.SaveChangesAsync();
            return Mapper.Map<BoardProblem, GetBoardProblemDTO>(problem);
        }
    }
}
