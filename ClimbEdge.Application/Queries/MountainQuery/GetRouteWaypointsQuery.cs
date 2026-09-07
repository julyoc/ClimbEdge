using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;

namespace ClimbEdge.Application.Queries.MountainQuery
{
    public record GetRouteWaypointsQuery(long MountainRouteId) : IRequest<IEnumerable<GetRouteWaypointDTO>>;

    public class GetRouteWaypointsQueryHandler : IRequestHandler<GetRouteWaypointsQuery, IEnumerable<GetRouteWaypointDTO>>
    {
        private readonly IRouteWaypointRepository _waypointRepository;

        public GetRouteWaypointsQueryHandler(IRouteWaypointRepository waypointRepository)
        {
            _waypointRepository = waypointRepository;
        }

        public async Task<IEnumerable<GetRouteWaypointDTO>> Handle(GetRouteWaypointsQuery request, CancellationToken cancellationToken)
        {
            var waypoints = await _waypointRepository.GetAsync(
                criteria: w => w.MountainRouteId == request.MountainRouteId && !w.IsDeleted);

            return waypoints
                .OrderBy(w => w.Sequence)
                .Select(w => new GetRouteWaypointDTO
                {
                    Uid = w.Uid,
                    Slug = w.Slug,
                    MountainRouteId = w.MountainRouteId,
                    Name = w.Name,
                    Description = w.Description,
                    Sequence = w.Sequence,
                    WaypointTypeId = w.WaypointTypeId,
                    EstimatedTimeFromPrevious = w.EstimatedTimeFromPrevious,
                    Notes = w.Notes,
                    ImageUrl = w.ImageUrl,
                    CreatedAt = w.CreatedAt,
                    UpdatedAt = w.UpdatedAt
                });
        }
    }
}
