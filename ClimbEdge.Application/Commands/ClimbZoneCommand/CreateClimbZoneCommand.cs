using ClimbEdge.Application.DTOs;
using ClimbEdge.Common.Utils;
using ClimbEdge.Domain.Entities.Climbing;
using ClimbEdge.Domain.Repositories.Climbing;
using MediatR;
using NetTopologySuite.IO;

namespace ClimbEdge.Application.Commands.ClimbZoneCommand
{
    public record CreateClimbZoneCommand(CreateClimbZoneDTO entity) : IRequest<GetClimbZoneDTO>;

    public class CreateClimbZoneCommandHandler : IRequestHandler<CreateClimbZoneCommand, GetClimbZoneDTO>
    {
        private readonly IClimbZoneRepository _climbZoneRepository;

        public CreateClimbZoneCommandHandler(IClimbZoneRepository climbZoneRepository)
        {
            _climbZoneRepository = climbZoneRepository;
        }

        public async Task<GetClimbZoneDTO> Handle(CreateClimbZoneCommand request, CancellationToken cancellationToken)
        {
            var zone = Mapper.Map<CreateClimbZoneDTO, ClimbZone>(request.entity);

            if (!string.IsNullOrWhiteSpace(request.entity.LocationWkt))
            {
                var reader = new WKTReader();
                zone.Location = reader.Read(request.entity.LocationWkt) as NetTopologySuite.Geometries.Point;
            }

            zone.InitializeSlug();
            await _climbZoneRepository.AddAsync(zone);
            await _climbZoneRepository.SaveChangesAsync();
            return ClimbZoneMapper.ToDTO(zone);
        }
    }

    internal static class ClimbZoneMapper
    {
        public static GetClimbZoneDTO ToDTO(ClimbZone zone)
        {
            var dto = Mapper.Map<ClimbZone, GetClimbZoneDTO>(zone);
            if (zone.Location != null)
            {
                dto = dto with { Latitude = zone.Location.Y, Longitude = zone.Location.X };
            }
            return dto;
        }
    }
}
