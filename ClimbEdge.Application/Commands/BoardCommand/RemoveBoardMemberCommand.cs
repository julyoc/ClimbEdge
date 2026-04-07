using ClimbEdge.Domain.Repositories.Boards;
using MediatR;

namespace ClimbEdge.Application.Commands.BoardCommand
{
    public record RemoveBoardMemberCommand(long BoardId, long UserId) : IRequest;

    public class RemoveBoardMemberCommandHandler : IRequestHandler<RemoveBoardMemberCommand>
    {
        private readonly IBoardMemberRepository _boardMemberRepository;

        public RemoveBoardMemberCommandHandler(IBoardMemberRepository boardMemberRepository)
        {
            _boardMemberRepository = boardMemberRepository;
        }

        public async Task Handle(RemoveBoardMemberCommand request, CancellationToken cancellationToken)
        {
            var members = await _boardMemberRepository.GetAsync(criteria: m =>
                m.BoardId == request.BoardId && m.UserId == request.UserId && !m.IsDeleted);
            var member = members.FirstOrDefault();
            if (member == null) throw new InvalidOperationException("Board member not found.");
            if (member.IsPropertyOwner) throw new InvalidOperationException("Cannot remove the board owner.");
            await _boardMemberRepository.DeleteAsync(member.Uid);
            await _boardMemberRepository.SaveChangesAsync();
        }
    }
}
