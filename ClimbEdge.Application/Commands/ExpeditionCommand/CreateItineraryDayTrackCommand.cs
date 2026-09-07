using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Entities.Mountains.Itinerary;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;
using NetTopologySuite.IO;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record CreateItineraryDayTrackCommand(CreateItineraryDayTrackDTO entity) : IRequest<GetItineraryDayTrackDTO>;

    public class CreateItineraryDayTrackCommandHandler : IRequestHandler<CreateItineraryDayTrackCommand, GetItineraryDayTrackDTO>
    {
        private readonly IItineraryDayTrackRepository _dayTrackRepository;

        public CreateItineraryDayTrackCommandHandler(IItineraryDayTrackRepository dayTrackRepository)
        {
            _dayTrackRepository = dayTrackRepository;
        }

        public async Task<GetItineraryDayTrackDTO> Handle(CreateItineraryDayTrackCommand request, CancellationToken cancellationToken)
        {
            var dto = request.entity;
            var reader = new WKTReader();

            var trackGeom = reader.Read(dto.TrackDataWkt);
            var trackLine = trackGeom as NetTopologySuite.Geometries.LineString
                ?? throw new ArgumentException("TrackDataWkt must be a valid LINESTRING.");

            NetTopologySuite.Geometries.LineString? plannedLine = null;
            if (!string.IsNullOrWhiteSpace(dto.PlannedRouteWkt))
            {
                plannedLine = reader.Read(dto.PlannedRouteWkt) as NetTopologySuite.Geometries.LineString;
            }

            var dayTrack = new ItineraryDayTrack
            {
                ItineraryDayId = dto.ItineraryDayId,
                ItineraryTrackId = dto.ItineraryTrackId,
                ParticipantId = dto.ParticipantId,
                Name = dto.Name,
                TrackData = trackLine,
                PlannedRoute = plannedLine,
                TotalDistance = dto.TotalDistance,
                MovingTime = dto.MovingTime,
                TotalTime = dto.TotalTime,
                MinElevation = dto.MinElevation,
                MaxElevation = dto.MaxElevation,
                ElevationGain = dto.ElevationGain,
                ElevationLoss = dto.ElevationLoss,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                RecordedBy = dto.RecordedBy,
                GpsDevice = dto.GpsDevice,
                Accuracy = dto.Accuracy,
                WeatherConditions = dto.WeatherConditions,
                Notes = dto.Notes,
                IsOfficial = dto.IsOfficial
            };

            dayTrack.InitializeSlug();
            await _dayTrackRepository.AddAsync(dayTrack);
            await _dayTrackRepository.SaveChangesAsync();

            return MapToDTO(dayTrack);
        }

        internal static GetItineraryDayTrackDTO MapToDTO(ItineraryDayTrack t) => new()
        {
            Uid = t.Uid,
            Slug = t.Slug,
            ItineraryDayId = t.ItineraryDayId,
            ItineraryTrackId = t.ItineraryTrackId,
            ParticipantId = t.ParticipantId,
            Name = t.Name,
            TotalDistance = t.TotalDistance,
            MovingTime = t.MovingTime,
            TotalTime = t.TotalTime,
            MinElevation = t.MinElevation,
            MaxElevation = t.MaxElevation,
            ElevationGain = t.ElevationGain,
            ElevationLoss = t.ElevationLoss,
            StartTime = t.StartTime,
            EndTime = t.EndTime,
            RecordedBy = t.RecordedBy,
            GpsDevice = t.GpsDevice,
            WeatherConditions = t.WeatherConditions,
            Notes = t.Notes,
            IsOfficial = t.IsOfficial,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt
        };
    }
}
