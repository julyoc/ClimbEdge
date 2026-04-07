using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Enums.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Queries.ExpeditionQuery
{
    public record GetExpeditionIncidentHistoryQuery(long ExpeditionId) : IRequest<IEnumerable<GetExpeditionIncidentDTO>>;

    public class GetExpeditionIncidentHistoryQueryHandler
        : IRequestHandler<GetExpeditionIncidentHistoryQuery, IEnumerable<GetExpeditionIncidentDTO>>
    {
        private readonly IMountainExpeditionLogRepository _logRepository;

        public GetExpeditionIncidentHistoryQueryHandler(IMountainExpeditionLogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<IEnumerable<GetExpeditionIncidentDTO>> Handle(
            GetExpeditionIncidentHistoryQuery request, CancellationToken cancellationToken)
        {
            var logs = await _logRepository.GetAsync(
                criteria: l => l.ExpeditionId == request.ExpeditionId
                            && l.TickType == MountaineerTickType.Rescue
                            && !l.IsDeleted);

            return logs.Select(l =>
            {
                l.SafetyIncidents ??= new Dictionary<string, object>();

                return new GetExpeditionIncidentDTO
                {
                    Uid                 = l.Uid,
                    Slug                = l.Slug,
                    ExpeditionId        = l.ExpeditionId!.Value,
                    UserId              = l.UserId!.Value,
                    Title               = l.Name,
                    IncidentDate        = l.StartDate,
                    Description         = l.Content ?? string.Empty,
                    Severity            = l.SafetyIncidents.TryGetValue("severity", out var sv) ? sv?.ToString() ?? "Unknown" : "Unknown",
                    ActionTaken         = l.SafetyIncidents.TryGetValue("actionTaken", out var at) ? at?.ToString() : null,
                    ElevationAtIncident = l.MaxElevationReached
                };
            });
        }
    }
}
