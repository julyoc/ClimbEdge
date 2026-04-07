using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;
using NetTopologySuite.IO;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record RecordExpeditionLogCommand(RecordExpeditionLogDTO entity) : IRequest<long>;

    public class RecordExpeditionLogCommandHandler : IRequestHandler<RecordExpeditionLogCommand, long>
    {
        private readonly IMountainExpeditionLogRepository _logRepository;

        public RecordExpeditionLogCommandHandler(IMountainExpeditionLogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<long> Handle(RecordExpeditionLogCommand request, CancellationToken cancellationToken)
        {
            var dto = request.entity;

            var log = new MountainExpeditionLog
            {
                ExpeditionId = dto.ExpeditionId,
                UserId = dto.UserId,
                GuideId = dto.GuideId,
                Name = dto.Name,
                Description = dto.Description,
                Content = dto.Content,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Duration = dto.Duration,
                MaxElevationReached = dto.MaxElevationReached,
                MinElevationReached = dto.MinElevationReached,
                WeatherConditions = dto.WeatherConditions,
                WeatherAtSummit = dto.WeatherAtSummit,
                Notes = dto.Notes,
                ChallengesFaced = dto.ChallengesFaced,
                EquipmentUsed = dto.EquipmentUsed,
                IsSuccessfull = dto.IsSuccessful,
                TickType = dto.TickType,
                GroupSize = dto.GroupSize,
                MountainRouteId = dto.MountainRouteId
            };

            if (!string.IsNullOrWhiteSpace(dto.RouteTakenWkt))
            {
                var reader = new WKTReader();
                var geom = reader.Read(dto.RouteTakenWkt);
                log.RouteTaken = geom as NetTopologySuite.Geometries.LineString;
            }

            log.InitializeSlug();

            await _logRepository.AddAsync(log);
            await _logRepository.SaveChangesAsync();

            return log.Id;
        }
    }
}
