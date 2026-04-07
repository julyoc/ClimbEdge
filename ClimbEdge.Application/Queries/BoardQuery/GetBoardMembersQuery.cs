using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Boards;
using ClimbEdge.Domain.Repositories.Boards;
using MediatR;

namespace ClimbEdge.Application.Queries.BoardQuery
{
    public record GetBoardMembersQuery(long BoardId) : IRequest<IEnumerable<GetBoardMemberDTO>>;

    public class GetBoardMembersQueryHandler : IRequestHandler<GetBoardMembersQuery, IEnumerable<GetBoardMemberDTO>>
    {
        private readonly IBoardMemberRepository _boardMemberRepository;

        public GetBoardMembersQueryHandler(IBoardMemberRepository boardMemberRepository)
        {
            _boardMemberRepository = boardMemberRepository;
        }

        public async Task<IEnumerable<GetBoardMemberDTO>> Handle(GetBoardMembersQuery request, CancellationToken cancellationToken)
        {
            var members = await _boardMemberRepository.GetAsync(
                criteria: m => m.BoardId == request.BoardId && !m.IsDeleted);
            return members.Select(m => Mapper.Map<BoardMember, GetBoardMemberDTO>(m));
        }
    }
}
