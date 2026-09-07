using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Entities.Mountains;
using ClimbEdge.Domain.Repositories.Mountains;
using MediatR;
using NetTopologySuite.IO;

namespace ClimbEdge.Application.Commands.MountainCommand
{
    public record CreateRouteWaypointCommand(CreateRouteWaypointDTO entity) : IRequest<GetRouteWaypointDTO>;

    public class CreateRouteWaypointCommandHandler : IRequestHandler<CreateRouteWaypointCommand, GetRouteWaypointDTO>
    {
        private readonly IRouteWaypointRepository _waypointRepository;

        public CreateRouteWaypointCommandHandler(IRouteWaypointRepository waypointRepository)
        {
            _waypointRepository = waypointRepository;
        }

        public async Task<GetRouteWaypointDTO> Handle(CreateRouteWaypointCommand request, CancellationToken cancellationToken)
        {
            var dto = request.entity;

            var reader = new WKTReader();
            var geom = reader.Read(dto.LocationWkt);
            var point = geom as NetTopologySuite.Geometries.Point
                ?? throw new ArgumentException("LocationWkt must be a valid POINT.");

            var waypoint = new RouteWaypoint
            {
                MountainRouteId = dto.MountainRouteId,
                Name = dto.Name,
                Description = dto.Description,
                Location = point,
                Sequence = dto.Sequence,
                WaypointTypeId = dto.WaypointTypeId,
                EstimatedTimeFromPrevious = dto.EstimatedTimeFromPrevious,
                Notes = dto.Notes,
                ImageUrl = dto.ImageUrl
            };

            waypoint.InitializeSlug();
            await _waypointRepository.AddAsync(waypoint);
            await _waypointRepository.SaveChangesAsync();

            return new GetRouteWaypointDTO
            {
                Uid = waypoint.Uid,
                Slug = waypoint.Slug,
                MountainRouteId = waypoint.MountainRouteId,
                Name = waypoint.Name,
                Description = waypoint.Description,
                Sequence = waypoint.Sequence,
                WaypointTypeId = waypoint.WaypointTypeId,
                EstimatedTimeFromPrevious = waypoint.EstimatedTimeFromPrevious,
                Notes = waypoint.Notes,
                ImageUrl = waypoint.ImageUrl,
                CreatedAt = waypoint.CreatedAt
            };
        }
    }
}
