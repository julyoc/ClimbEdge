using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Enums.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record WriteExpeditionDebriefCommand(WriteExpeditionDebriefDTO entity) : IRequest<long>;

    public class WriteExpeditionDebriefCommandHandler : IRequestHandler<WriteExpeditionDebriefCommand, long>
    {
        private readonly IMountainExpeditionLogRepository _logRepository;

        public WriteExpeditionDebriefCommandHandler(IMountainExpeditionLogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<long> Handle(WriteExpeditionDebriefCommand request, CancellationToken cancellationToken)
        {
            var dto = request.entity;

            var notes = new List<string> { dto.LessonsLearned };
            if (!string.IsNullOrWhiteSpace(dto.TechnicalAssessment))
                notes.Add($"Technical: {dto.TechnicalAssessment}");
            if (!string.IsNullOrWhiteSpace(dto.TeamDynamics))
                notes.Add($"Team: {dto.TeamDynamics}");
            if (!string.IsNullOrWhiteSpace(dto.EquipmentNotes))
                notes.Add($"Equipment: {dto.EquipmentNotes}");
            if (!string.IsNullOrWhiteSpace(dto.RecommendationsForFutureTeams))
                notes.Add($"Recommendations: {dto.RecommendationsForFutureTeams}");

            var log = new MountainExpeditionLog
            {
                ExpeditionId  = dto.ExpeditionId,
                UserId        = dto.UserId,
                Name          = dto.Title,
                StartDate     = DateTime.UtcNow,
                Content       = dto.PersonalReflection,
                Description   = dto.LessonsLearned,
                Notes         = notes.ToArray(),
                IsSuccessfull = true,
                TickType      = MountaineerTickType.Debrief
            };

            log.InitializeSlug();

            await _logRepository.AddAsync(log);
            await _logRepository.SaveChangesAsync();

            return log.Id;
        }
    }
}
