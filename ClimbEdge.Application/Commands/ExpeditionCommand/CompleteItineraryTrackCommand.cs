using ClimbEdge.Application.DTOs;
using ClimbEdge.Domain.Repositories.Mountains.Itinerary;
using MediatR;
using NetTopologySuite.IO;

namespace ClimbEdge.Application.Commands.ExpeditionCommand
{
    public record CompleteItineraryTrackCommand(CompleteItineraryTrackDTO entity) : IRequest;

    public class CompleteItineraryTrackCommandHandler : IRequestHandler<CompleteItineraryTrackCommand>
    {
        private readonly IItineraryTrackRepository _trackRepository;

        public CompleteItineraryTrackCommandHandler(IItineraryTrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }

        public async Task Handle(CompleteItineraryTrackCommand request, CancellationToken cancellationToken)
        {
            var dto = request.entity;

            var track = (await _trackRepository.GetAsync(
                criteria: t => t.Id == dto.TrackId && !t.IsDeleted))
                .FirstOrDefault()
                ?? throw new KeyNotFoundException($"Itinerary track {dto.TrackId} not found.");

            track.EndDate = dto.EndDate;
            track.ActualDistance = dto.ActualDistance;
            track.ActualDuration = dto.ActualDuration;
            track.MinElevation = dto.MinElevation;
            track.MaxElevation = dto.MaxElevation;
            track.CumulativeElevationGain = dto.CumulativeElevationGain;
            track.CumulativeElevationLoss = dto.CumulativeElevationLoss;
            track.CompletionPercentage = dto.CompletionPercentage;
            track.RouteDeviation = dto.RouteDeviation;
            track.WeatherSummary = dto.WeatherSummary;
            track.DifficultySummary = dto.DifficultySummary;
            track.Notes = dto.Notes;

            if (!string.IsNullOrWhiteSpace(dto.ActualRouteWkt))
            {
                var reader = new WKTReader();
                var geom = reader.Read(dto.ActualRouteWkt);
                track.ActualRoute = geom as NetTopologySuite.Geometries.LineString;
            }

            track.UpdateTimestamps();
            await _trackRepository.UpdateAsync(track);
            await _trackRepository.SaveChangesAsync();
        }
    }
}
