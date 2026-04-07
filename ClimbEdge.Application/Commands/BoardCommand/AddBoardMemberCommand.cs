using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Boards;
using ClimbEdge.Domain.Repositories.Boards;
using MediatR;

namespace ClimbEdge.Application.Commands.BoardCommand
{
    public record AddBoardMemberCommand(AddBoardMemberDTO entity) : IRequest<GetBoardMemberDTO>;

    public class AddBoardMemberCommandHandler : IRequestHandler<AddBoardMemberCommand, GetBoardMemberDTO>
    {
        private readonly IBoardMemberRepository _boardMemberRepository;
        private readonly IBoardRepository _boardRepository;

        public AddBoardMemberCommandHandler(IBoardMemberRepository boardMemberRepository, IBoardRepository boardRepository)
        {
            _boardMemberRepository = boardMemberRepository;
            _boardRepository = boardRepository;
        }

        public async Task<GetBoardMemberDTO> Handle(AddBoardMemberCommand request, CancellationToken cancellationToken)
        {
            var boardExists = await _boardRepository.ExistsAsync(request.entity.BoardId.ToString());
            if (!boardExists) throw new InvalidOperationException("Board not found.");

            var existing = await _boardMemberRepository.GetAsync(criteria: m =>
                m.BoardId == request.entity.BoardId && m.UserId == request.entity.UserId && !m.IsDeleted);
            if (existing.Any()) throw new InvalidOperationException("User is already a member of this board.");

            var member = new BoardMember
            {
                BoardId = request.entity.BoardId,
                UserId = request.entity.UserId,
                Role = request.entity.Role
            };
            await _boardMemberRepository.AddAsync(member);
            await _boardMemberRepository.SaveChangesAsync();
            return Mapper.Map<BoardMember, GetBoardMemberDTO>(member);
        }
    }
}
