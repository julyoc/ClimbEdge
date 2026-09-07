using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;
using NetTopologySuite.IO;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record CreateItineraryDayWaypointCommand(CreateItineraryDayWaypointDTO entity) : IRequest<GetItineraryDayWaypointDTO>;

    public class CreateItineraryDayWaypointCommandHandler : IRequestHandler<CreateItineraryDayWaypointCommand, GetItineraryDayWaypointDTO>
    {
        private readonly IItineraryDayWaypointRepository _waypointRepository;

        public CreateItineraryDayWaypointCommandHandler(IItineraryDayWaypointRepository waypointRepository)
        {
            _waypointRepository = waypointRepository;
        }

        public async Task<GetItineraryDayWaypointDTO> Handle(CreateItineraryDayWaypointCommand request, CancellationToken cancellationToken)
        {
            var dto = request.entity;
            var reader = new WKTReader();
            var geom = reader.Read(dto.LocationWkt);
            var point = geom as NetTopologySuite.Geometries.Point
                ?? throw new ArgumentException("LocationWkt must be a valid POINT.");

            var waypoint = new ItineraryDayWaypoint
            {
                ItineraryDayId = dto.ItineraryDayId,
                ItineraryDayTrackId = dto.ItineraryDayTrackId,
                Name = dto.Name,
                Description = dto.Description,
                Location = point,
                Elevation = dto.Elevation,
                Timestamp = dto.Timestamp,
                WaypointTypeId = dto.WaypointTypeId,
                Duration = dto.Duration,
                Photo = dto.Photo,
                Notes = dto.Notes,
                RecordedBy = dto.RecordedBy,
                WeatherConditions = dto.WeatherConditions,
                Temperature = dto.Temperature,
                IsPlanned = dto.IsPlanned,
                IsEmergency = dto.IsEmergency
            };

            waypoint.InitializeSlug();
            await _waypointRepository.AddAsync(waypoint);
            await _waypointRepository.SaveChangesAsync();

            return MapToDTO(waypoint);
        }

        internal static GetItineraryDayWaypointDTO MapToDTO(ItineraryDayWaypoint w) => new()
        {
            Uid = w.Uid,
            Slug = w.Slug,
            ItineraryDayId = w.ItineraryDayId,
            ItineraryDayTrackId = w.ItineraryDayTrackId,
            Name = w.Name,
            Description = w.Description,
            Elevation = w.Elevation,
            Timestamp = w.Timestamp,
            WaypointTypeId = w.WaypointTypeId,
            Duration = w.Duration,
            Photo = w.Photo,
            Notes = w.Notes,
            RecordedBy = w.RecordedBy,
            WeatherConditions = w.WeatherConditions,
            Temperature = w.Temperature,
            IsPlanned = w.IsPlanned,
            IsEmergency = w.IsEmergency,
            CreatedAt = w.CreatedAt,
            UpdatedAt = w.UpdatedAt
        };
    }
}
