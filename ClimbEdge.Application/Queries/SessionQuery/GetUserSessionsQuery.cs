using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Sessions;
using ClimbEdge.Domain.Interfaces;
using ClimbEdge.Domain.Repositories.Sessions;
using MediatR;

namespace ClimbEdge.Application.Queries.SessionQuery
{
    public record GetUserSessionsQuery(long UserId, bool? ActiveOnly = null, int Page = 1, int PageSize = 20) : IRequest<IEnumerable<GetSessionDTO>>;

    public class GetUserSessionsQueryHandler : IRequestHandler<GetUserSessionsQuery, IEnumerable<GetSessionDTO>>
    {
        private readonly IUserSessionRepository _userSessionRepository;

        public GetUserSessionsQueryHandler(IUserSessionRepository userSessionRepository)
        {
            _userSessionRepository = userSessionRepository;
        }

        public async Task<IEnumerable<GetSessionDTO>> Handle(GetUserSessionsQuery request, CancellationToken cancellationToken)
        {
            var sessions = await _userSessionRepository.GetAsync(
                page: request.Page,
                criteria: s => s.UserId == request.UserId
                    && !s.IsDeleted
                    && (request.ActiveOnly == null
                        || (request.ActiveOnly == true && s.EndedAt == null)
                        || (request.ActiveOnly == false && s.EndedAt != null)),
                orderSelectors: new[] { new OrderSelectors("StartedAt", true) },
                pageSize: request.PageSize
            );
            return sessions.Select(s => Mapper.Map<UserSession, GetSessionDTO>(s));
        }
    }
}
