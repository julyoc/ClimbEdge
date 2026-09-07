using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;
using NetTopologySuite.IO;

namespace ClimbEdge.Application.Commands.MountainCommand
{
    public record CreateRouteTrackCommand(CreateRouteTrackDTO entity) : IRequest<GetRouteTrackDTO>;

    public class CreateRouteTrackCommandHandler : IRequestHandler<CreateRouteTrackCommand, GetRouteTrackDTO>
    {
        private readonly IRouteTrackRepository _routeTrackRepository;

        public CreateRouteTrackCommandHandler(IRouteTrackRepository routeTrackRepository)
        {
            _routeTrackRepository = routeTrackRepository;
        }

        public async Task<GetRouteTrackDTO> Handle(CreateRouteTrackCommand request, CancellationToken cancellationToken)
        {
            var dto = request.entity;

            var reader = new WKTReader();
            var geom = reader.Read(dto.TrackDataWkt);
            var trackLine = geom as NetTopologySuite.Geometries.LineString
                ?? throw new ArgumentException("TrackDataWkt must be a valid LINESTRING.");

            var track = new RouteTrack
            {
                MountainRouteId = dto.MountainRouteId,
                Name = dto.Name,
                TrackData = trackLine,
                TotalDistance = dto.TotalDistance,
                MinElevation = dto.MinElevation,
                MaxElevation = dto.MaxElevation,
                RecordedBy = dto.RecordedBy,
                RecordedAt = dto.RecordedAt,
                GpsDevice = dto.GpsDevice,
                Accuracy = dto.Accuracy
            };

            track.InitializeSlug();
            await _routeTrackRepository.AddAsync(track);
            await _routeTrackRepository.SaveChangesAsync();

            return new GetRouteTrackDTO
            {
                Uid = track.Uid,
                Slug = track.Slug,
                MountainRouteId = track.MountainRouteId,
                Name = track.Name,
                TotalDistance = track.TotalDistance,
                MinElevation = track.MinElevation,
                MaxElevation = track.MaxElevation,
                RecordedBy = track.RecordedBy,
                RecordedAt = track.RecordedAt,
                GpsDevice = track.GpsDevice,
                Accuracy = track.Accuracy,
                CreatedAt = track.CreatedAt
            };
        }
    }
}
