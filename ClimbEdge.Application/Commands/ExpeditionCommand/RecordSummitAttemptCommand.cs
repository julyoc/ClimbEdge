using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;
using NetTopologySuite.IO;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record RecordSummitAttemptCommand(RecordSummitAttemptDTO entity) : IRequest<long>;

    public class RecordSummitAttemptCommandHandler : IRequestHandler<RecordSummitAttemptCommand, long>
    {
        private readonly IMountainExpeditionLogRepository _logRepository;

        public RecordSummitAttemptCommandHandler(IMountainExpeditionLogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<long> Handle(RecordSummitAttemptCommand request, CancellationToken cancellationToken)
        {
            var dto = request.entity;

            var log = new MountainExpeditionLog
            {
                ExpeditionId    = dto.ExpeditionId,
                UserId          = dto.UserId,
                GuideId         = dto.GuideId,
                Name            = dto.Name,
                StartDate       = dto.AttemptDate,
                EndDate         = dto.EndDate,
                MaxElevationReached = dto.MaxElevationReached,
                WeatherAtSummit = dto.WeatherAtSummit,
                WeatherConditions = dto.WeatherConditions,
                ChallengesFaced = dto.ChallengesFaced,
                EquipmentUsed   = dto.EquipmentUsed,
                Notes           = dto.Notes is not null ? new[] { dto.Notes } : null,
                IsSuccessfull   = dto.Result == Domain.Enums.Mountains.Itinerary.MountaineerTickType.Summit,
                TickType        = dto.Result,
                GroupSize       = dto.GroupSize,
                MountainRouteId = dto.MountainRouteId
            };

            if (!string.IsNullOrWhiteSpace(dto.RouteTakenWkt))
            {
                var geom = new WKTReader().Read(dto.RouteTakenWkt);
                log.RouteTaken = geom as NetTopologySuite.Geometries.LineString;
            }

            log.InitializeSlug();

            await _logRepository.AddAsync(log);
            await _logRepository.SaveChangesAsync();

            return log.Id;
        }
    }
}
