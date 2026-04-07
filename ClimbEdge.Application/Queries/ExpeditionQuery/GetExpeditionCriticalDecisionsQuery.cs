using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Enums.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Queries.ExpeditionQuery
{
    public record GetExpeditionCriticalDecisionsQuery(long ExpeditionId) : IRequest<IEnumerable<GetCriticalDecisionDTO>>;

    public class GetExpeditionCriticalDecisionsQueryHandler
        : IRequestHandler<GetExpeditionCriticalDecisionsQuery, IEnumerable<GetCriticalDecisionDTO>>
    {
        private readonly IMountainExpeditionLogRepository _logRepository;

        public GetExpeditionCriticalDecisionsQueryHandler(IMountainExpeditionLogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<IEnumerable<GetCriticalDecisionDTO>> Handle(
            GetExpeditionCriticalDecisionsQuery request, CancellationToken cancellationToken)
        {
            var logs = await _logRepository.GetAsync(
                criteria: l => l.ExpeditionId == request.ExpeditionId
                            && l.TickType == MountaineerTickType.Decision
                            && !l.IsDeleted);

            return logs.Select(l => new GetCriticalDecisionDTO
            {
                Uid                 = l.Uid,
                Slug                = l.Slug,
                ExpeditionId        = l.ExpeditionId!.Value,
                UserId              = l.UserId!.Value,
                Title               = l.Name,
                DecisionDate        = l.StartDate,
                DecisionType        = l.Notes?.FirstOrDefault() ?? string.Empty,
                Rationale           = l.Content ?? string.Empty,
                ElevationAtDecision = l.MaxElevationReached
            });
        }
    }
}
