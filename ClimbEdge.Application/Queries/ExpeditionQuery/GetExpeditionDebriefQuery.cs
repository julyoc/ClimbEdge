using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Enums.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Queries.ExpeditionQuery
{
    public record GetExpeditionDebriefQuery(long ExpeditionId) : IRequest<GetExpeditionDebriefDTO?>;

    public class GetExpeditionDebriefQueryHandler : IRequestHandler<GetExpeditionDebriefQuery, GetExpeditionDebriefDTO?>
    {
        private readonly IMountainExpeditionLogRepository _logRepository;

        public GetExpeditionDebriefQueryHandler(IMountainExpeditionLogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<GetExpeditionDebriefDTO?> Handle(GetExpeditionDebriefQuery request, CancellationToken cancellationToken)
        {
            var logs = await _logRepository.GetAsync(
                criteria: l => l.ExpeditionId == request.ExpeditionId
                    && l.TickType == MountaineerTickType.Debrief
                    && !l.IsDeleted);

            var log = logs.OrderByDescending(l => l.CreatedAt).FirstOrDefault();
            if (log == null) return null;

            // Notes are stored as: LessonsLearned, Technical: ..., Team: ..., Equipment: ..., Recommendations: ...
            string? technical = null, team = null, equipment = null, recommendations = null;
            if (log.Notes != null)
            {
                foreach (var note in log.Notes)
                {
                    if (note.StartsWith("Technical: ")) technical = note["Technical: ".Length..];
                    else if (note.StartsWith("Team: ")) team = note["Team: ".Length..];
                    else if (note.StartsWith("Equipment: ")) equipment = note["Equipment: ".Length..];
                    else if (note.StartsWith("Recommendations: ")) recommendations = note["Recommendations: ".Length..];
                }
            }

            return new GetExpeditionDebriefDTO
            {
                Uid = log.Uid,
                Slug = log.Slug,
                ExpeditionId = log.ExpeditionId ?? request.ExpeditionId,
                UserId = log.UserId ?? 0,
                Title = log.Name,
                LessonsLearned = log.Description ?? string.Empty,
                TechnicalAssessment = technical,
                TeamDynamics = team,
                EquipmentNotes = equipment,
                RecommendationsForFutureTeams = recommendations,
                CreatedAt = log.CreatedAt,
                UpdatedAt = log.UpdatedAt
            };
        }
    }
}
