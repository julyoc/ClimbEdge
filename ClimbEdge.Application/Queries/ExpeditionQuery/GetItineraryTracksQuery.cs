using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Queries.ExpeditionQuery
{
    public record GetItineraryTracksQuery(long ExpeditionId) : IRequest<IEnumerable<GetItineraryTrackDTO>>;

    public class GetItineraryTracksQueryHandler
        : IRequestHandler<GetItineraryTracksQuery, IEnumerable<GetItineraryTrackDTO>>
    {
        private readonly IItineraryTrackRepository _trackRepository;

        public GetItineraryTracksQueryHandler(IItineraryTrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }

        public async Task<IEnumerable<GetItineraryTrackDTO>> Handle(
            GetItineraryTracksQuery request, CancellationToken cancellationToken)
        {
            var tracks = await _trackRepository.GetAsync(
                criteria: t => t.ExpeditionId == request.ExpeditionId && !t.IsDeleted);

            return tracks.Select(t => Mapper.Map<ItineraryTrack, GetItineraryTrackDTO>(t));
        }
    }
}
