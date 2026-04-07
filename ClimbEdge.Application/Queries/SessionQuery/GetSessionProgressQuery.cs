using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Sessions;
using ClimbEdge.Domain.Repositories.Sessions;
using MediatR;

namespace ClimbEdge.Application.Queries.SessionQuery
{
    public record GetSessionProgressQuery(long UserSessionId) : IRequest<IEnumerable<GetProgressDTO>>;

    public class GetSessionProgressQueryHandler
        : IRequestHandler<GetSessionProgressQuery, IEnumerable<GetProgressDTO>>
    {
        private readonly IUserSessionProgressRepository _progressRepository;

        public GetSessionProgressQueryHandler(IUserSessionProgressRepository progressRepository)
        {
            _progressRepository = progressRepository;
        }

        public async Task<IEnumerable<GetProgressDTO>> Handle(
            GetSessionProgressQuery request, CancellationToken cancellationToken)
        {
            var records = await _progressRepository.GetAsync(
                criteria: p => p.UserSessionId == request.UserSessionId);

            return records.Select(p => Mapper.Map<UserSessionProgress, GetProgressDTO>(p));
        }
    }
}
