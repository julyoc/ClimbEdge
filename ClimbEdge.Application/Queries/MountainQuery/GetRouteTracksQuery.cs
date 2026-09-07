using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Queries.MountainQuery
{
    public record GetRouteTracksQuery(long MountainRouteId) : IRequest<IEnumerable<GetRouteTrackDTO>>;

    public class GetRouteTracksQueryHandler : IRequestHandler<GetRouteTracksQuery, IEnumerable<GetRouteTrackDTO>>
    {
        private readonly IRouteTrackRepository _routeTrackRepository;

        public GetRouteTracksQueryHandler(IRouteTrackRepository routeTrackRepository)
        {
            _routeTrackRepository = routeTrackRepository;
        }

        public async Task<IEnumerable<GetRouteTrackDTO>> Handle(GetRouteTracksQuery request, CancellationToken cancellationToken)
        {
            var tracks = await _routeTrackRepository.GetAsync(
                criteria: t => t.MountainRouteId == request.MountainRouteId && !t.IsDeleted);

            return tracks.Select(t => new GetRouteTrackDTO
            {
                Uid = t.Uid,
                Slug = t.Slug,
                MountainRouteId = t.MountainRouteId,
                Name = t.Name,
                TotalDistance = t.TotalDistance,
                MinElevation = t.MinElevation,
                MaxElevation = t.MaxElevation,
                RecordedBy = t.RecordedBy,
                RecordedAt = t.RecordedAt,
                GpsDevice = t.GpsDevice,
                Accuracy = t.Accuracy,
                CreatedAt = t.CreatedAt,
                UpdatedAt = t.UpdatedAt
            });
        }
    }
}
