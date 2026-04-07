using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;
using NetTopologySuite.IO;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record CreateItineraryTrackCommand(CreateItineraryTrackDTO entity) : IRequest<long>;

    public class CreateItineraryTrackCommandHandler : IRequestHandler<CreateItineraryTrackCommand, long>
    {
        private readonly IItineraryTrackRepository _trackRepository;

        public CreateItineraryTrackCommandHandler(IItineraryTrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }

        public async Task<long> Handle(CreateItineraryTrackCommand request, CancellationToken cancellationToken)
        {
            var dto = request.entity;

            var track = new ItineraryTrack
            {
                ExpeditionId = dto.ExpeditionId,
                Name = dto.Name,
                Description = dto.Description,
                TrackType = dto.TrackType,
                StartDayNumber = dto.StartDayNumber,
                EndDayNumber = dto.EndDayNumber,
                StartDate = dto.StartDate,
                PlannedDistance = dto.PlannedDistance,
                PlannedDuration = dto.PlannedDuration,
                RecordedBy = dto.RecordedBy,
                GpsDevice = dto.GpsDevice
            };

            if (!string.IsNullOrWhiteSpace(dto.PlannedRouteWkt))
            {
                var reader = new WKTReader();
                var geom = reader.Read(dto.PlannedRouteWkt);
                track.PlannedRoute = geom as NetTopologySuite.Geometries.LineString;
            }

            track.InitializeSlug();

            await _trackRepository.AddAsync(track);
            await _trackRepository.SaveChangesAsync();

            return track.Id;
        }
    }
}
