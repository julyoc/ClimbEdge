using ClimbEdge.Application.Commands.ExpeditionCommand;
using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;

namespace ClimbEdge.Application.Queries.ExpeditionQuery
{
    public record GetItineraryDayWaypointsQuery(long ItineraryDayId) : IRequest<IEnumerable<GetItineraryDayWaypointDTO>>;

    public class GetItineraryDayWaypointsQueryHandler : IRequestHandler<GetItineraryDayWaypointsQuery, IEnumerable<GetItineraryDayWaypointDTO>>
    {
        private readonly IItineraryDayWaypointRepository _waypointRepository;

        public GetItineraryDayWaypointsQueryHandler(IItineraryDayWaypointRepository waypointRepository)
        {
            _waypointRepository = waypointRepository;
        }

        public async Task<IEnumerable<GetItineraryDayWaypointDTO>> Handle(GetItineraryDayWaypointsQuery request, CancellationToken cancellationToken)
        {
            var waypoints = await _waypointRepository.GetAsync(
                criteria: w => w.ItineraryDayId == request.ItineraryDayId && !w.IsDeleted);

            return waypoints
                .OrderBy(w => w.Timestamp)
                .Select(CreateItineraryDayWaypointCommandHandler.MapToDTO);
        }
    }
}
