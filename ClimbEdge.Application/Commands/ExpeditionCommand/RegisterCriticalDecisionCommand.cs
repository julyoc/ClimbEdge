using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Enums.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record RegisterCriticalDecisionCommand(RegisterCriticalDecisionDTO entity) : IRequest<long>;

    public class RegisterCriticalDecisionCommandHandler : IRequestHandler<RegisterCriticalDecisionCommand, long>
    {
        private readonly IMountainExpeditionLogRepository _logRepository;

        public RegisterCriticalDecisionCommandHandler(IMountainExpeditionLogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<long> Handle(RegisterCriticalDecisionCommand request, CancellationToken cancellationToken)
        {
            var dto = request.entity;

            var log = new MountainExpeditionLog
            {
                ExpeditionId        = dto.ExpeditionId,
                UserId              = dto.UserId,
                Name                = dto.Title,
                StartDate           = dto.DecisionDate,
                MaxElevationReached = dto.ElevationAtDecision,
                WeatherConditions   = dto.WeatherConditions,
                Content             = dto.Rationale,
                Description         = dto.Context,
                Notes               = new[] { dto.DecisionType },
                IsSuccessfull       = true,
                TickType            = MountaineerTickType.Decision
            };

            log.InitializeSlug();

            await _logRepository.AddAsync(log);
            await _logRepository.SaveChangesAsync();

            return log.Id;
        }
    }
}
