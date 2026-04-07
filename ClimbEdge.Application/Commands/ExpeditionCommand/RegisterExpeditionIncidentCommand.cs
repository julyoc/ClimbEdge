using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Enums.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record RegisterExpeditionIncidentCommand(RegisterExpeditionIncidentDTO entity) : IRequest<long>;

    public class RegisterExpeditionIncidentCommandHandler : IRequestHandler<RegisterExpeditionIncidentCommand, long>
    {
        private readonly IMountainExpeditionLogRepository _logRepository;

        public RegisterExpeditionIncidentCommandHandler(IMountainExpeditionLogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<long> Handle(RegisterExpeditionIncidentCommand request, CancellationToken cancellationToken)
        {
            var dto = request.entity;

            var safetyIncidents = new Dictionary<string, object>
            {
                ["severity"]       = dto.Severity,
                ["description"]    = dto.Description,
                ["actionTaken"]    = dto.ActionTaken ?? string.Empty,
                ["personsInvolved"] = dto.PersonsInvolved ?? Array.Empty<string>()
            };

            var log = new MountainExpeditionLog
            {
                ExpeditionId        = dto.ExpeditionId,
                UserId              = dto.UserId,
                Name                = dto.Title,
                StartDate           = dto.IncidentDate,
                MaxElevationReached = dto.ElevationAtIncident,
                WeatherConditions   = dto.WeatherConditions,
                Content             = dto.Description,
                ChallengesFaced     = new[] { dto.Description },
                IsSuccessfull       = false,
                TickType            = MountaineerTickType.Rescue,
                SafetyIncidents     = safetyIncidents
            };

            log.InitializeSlug();

            await _logRepository.AddAsync(log);
            await _logRepository.SaveChangesAsync();

            return log.Id;
        }
    }
}
