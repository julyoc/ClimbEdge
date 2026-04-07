using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Enums.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Queries.ExpeditionQuery
{
    public record GetExpeditionSummitHistoryQuery(long ExpeditionId) : IRequest<IEnumerable<GetSummitAttemptDTO>>;

    public class GetExpeditionSummitHistoryQueryHandler
        : IRequestHandler<GetExpeditionSummitHistoryQuery, IEnumerable<GetSummitAttemptDTO>>
    {
        private readonly IMountainExpeditionLogRepository _logRepository;

        public GetExpeditionSummitHistoryQueryHandler(IMountainExpeditionLogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<IEnumerable<GetSummitAttemptDTO>> Handle(
            GetExpeditionSummitHistoryQuery request, CancellationToken cancellationToken)
        {
            var summitTypes = new[]
            {
                MountaineerTickType.Summit,
                MountaineerTickType.Attempted,
                MountaineerTickType.Abandoned,
                MountaineerTickType.Failed
            };

            var logs = await _logRepository.GetAsync(
                criteria: l => l.ExpeditionId == request.ExpeditionId
                            && summitTypes.Contains(l.TickType)
                            && !l.IsDeleted);

            return logs.Select(l => new GetSummitAttemptDTO
            {
                Uid             = l.Uid,
                Slug            = l.Slug,
                ExpeditionId    = l.ExpeditionId!.Value,
                UserId          = l.UserId!.Value,
                Name            = l.Name,
                AttemptDate     = l.StartDate,
                EndDate         = l.EndDate,
                MaxElevationReached = l.MaxElevationReached ?? 0,
                Result          = l.TickType,
                WeatherAtSummit = l.WeatherAtSummit,
                GroupSize       = l.GroupSize
            });
        }
    }
}
