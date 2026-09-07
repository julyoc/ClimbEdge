using ClimbEdge.Application.DTOs;
using ClimbEdge.Application.Commands.ExpeditionCommand;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Queries.ExpeditionQuery
{
    public record GetItineraryDayTracksQuery(long ItineraryDayId) : IRequest<IEnumerable<GetItineraryDayTrackDTO>>;

    public class GetItineraryDayTracksQueryHandler : IRequestHandler<GetItineraryDayTracksQuery, IEnumerable<GetItineraryDayTrackDTO>>
    {
        private readonly IItineraryDayTrackRepository _dayTrackRepository;

        public GetItineraryDayTracksQueryHandler(IItineraryDayTrackRepository dayTrackRepository)
        {
            _dayTrackRepository = dayTrackRepository;
        }

        public async Task<IEnumerable<GetItineraryDayTrackDTO>> Handle(GetItineraryDayTracksQuery request, CancellationToken cancellationToken)
        {
            var tracks = await _dayTrackRepository.GetAsync(
                criteria: t => t.ItineraryDayId == request.ItineraryDayId && !t.IsDeleted);

            return tracks.Select(CreateItineraryDayTrackCommandHandler.MapToDTO);
        }
    }
}
