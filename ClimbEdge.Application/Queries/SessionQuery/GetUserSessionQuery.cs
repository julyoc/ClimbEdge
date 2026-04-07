using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Sessions;
using ClimbEdge.Domain.Repositories.Sessions;
using MediatR;

namespace ClimbEdge.Application.Queries.SessionQuery
{
    public record GetUserSessionQuery(Guid SessionUid) : IRequest<GetSessionDTO?>;

    public class GetUserSessionQueryHandler : IRequestHandler<GetUserSessionQuery, GetSessionDTO?>
    {
        private readonly IUserSessionRepository _userSessionRepository;

        public GetUserSessionQueryHandler(IUserSessionRepository userSessionRepository)
        {
            _userSessionRepository = userSessionRepository;
        }

        public async Task<GetSessionDTO?> Handle(GetUserSessionQuery request, CancellationToken cancellationToken)
        {
            var session = await _userSessionRepository.GetAsync(request.SessionUid);
            if (session == null) return null;
            return Mapper.Map<UserSession, GetSessionDTO>(session);
        }
    }
}
