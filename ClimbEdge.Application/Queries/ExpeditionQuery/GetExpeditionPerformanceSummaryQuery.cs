using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Enums.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Queries.ExpeditionQuery
{
    public record GetExpeditionPerformanceSummaryQuery(Guid ExpeditionUid) : IRequest<GetExpeditionPerformanceSummaryDTO>;

    public class GetExpeditionPerformanceSummaryQueryHandler
        : IRequestHandler<GetExpeditionPerformanceSummaryQuery, GetExpeditionPerformanceSummaryDTO>
    {
        private readonly IExpeditionRepository _expeditionRepository;
        private readonly IMountainExpeditionLogRepository _logRepository;
        private readonly IExpeditionParticipantRepository _participantRepository;

        public GetExpeditionPerformanceSummaryQueryHandler(
            IExpeditionRepository expeditionRepository,
            IMountainExpeditionLogRepository logRepository,
            IExpeditionParticipantRepository participantRepository)
        {
            _expeditionRepository  = expeditionRepository;
            _logRepository         = logRepository;
            _participantRepository = participantRepository;
        }

        public async Task<GetExpeditionPerformanceSummaryDTO> Handle(
            GetExpeditionPerformanceSummaryQuery request, CancellationToken cancellationToken)
        {
            var expedition = await _expeditionRepository.GetAsync(request.ExpeditionUid);
            if (expedition is null)
                throw new InvalidOperationException($"Expedition {request.ExpeditionUid} not found.");

            long expeditionId = expedition.Id;

            var logs = (await _logRepository.GetAsync(
                criteria: l => l.ExpeditionId == expeditionId && !l.IsDeleted)).ToList();

            var participants = await _participantRepository.GetAsync(
                criteria: p => p.ExpeditionId == expeditionId && !p.IsDeleted);

            var summitTypes = new[]
            {
                MountaineerTickType.Summit,
                MountaineerTickType.Attempted,
                MountaineerTickType.Abandoned,
                MountaineerTickType.Failed
            };

            int summitAttempts    = logs.Count(l => summitTypes.Contains(l.TickType));
            int successfulSummits = logs.Count(l => l.TickType == MountaineerTickType.Summit && l.IsSuccessfull);
            int totalIncidents    = logs.Count(l => l.TickType == MountaineerTickType.Rescue);
            int totalDecisions    = logs.Count(l => l.TickType == MountaineerTickType.Decision);
            bool hasDebrief       = logs.Any(l => l.TickType == MountaineerTickType.Debrief);

            int? maxElevation = logs
                .Where(l => l.MaxElevationReached.HasValue)
                .Select(l => l.MaxElevationReached)
                .DefaultIfEmpty(null)
                .Max();

            return new GetExpeditionPerformanceSummaryDTO
            {
                ExpeditionId      = expedition.Id,
                ExpeditionName    = expedition.Name,
                Status            = expedition.Status,
                TotalLogs         = logs.Count,
                SummitAttempts    = summitAttempts,
                SuccessfulSummits = successfulSummits,
                TotalIncidents    = totalIncidents,
                TotalDecisions    = totalDecisions,
                MaxElevationReached = maxElevation,
                TotalParticipants = participants.Count(),
                HasDebrief        = hasDebrief
            };
        }
    }
}
